using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

// TODO: separate Read & Write

namespace System
{
    /// <summary>
    /// Use call context (rather passing parameter through the call stack)
    /// for tracing environmental data (in multi-tenant environment).    /// 
    /// </summary>
    [Obsolete("Deprecating  ExecutionContext because it's to diverse fitting broad companies needs. This API will be removed on the next version. Please copy the code (from GitHub) into your local project if you're using it", false)]
    public class ExecutionContext
    {
        private static readonly AsyncLocal<ExecutionContext> _default = new AsyncLocal<ExecutionContext>();

        #region Value

        /// <summary>
        /// Gets or sets the context value.
        /// </summary>
        [Obsolete("Use Context or ExecCtx instead of Value", false)]
        public static ExecutionContext Value { get => Context; set => Context = value; }

        #endregion // Value

        #region Context

        /// <summary>
        /// Gets or sets the context value.
        /// You can shorten the syntax by: 
        /// using static System.ExecutionContext;
        /// Then you can use Context directly.
        /// </summary>
        public static ExecutionContext Context { get => _default.Value; set => _default.Value = value; }

        #endregion // Context

        #region ExecCtx

        /// <summary>
        /// Gets or sets the context value.
        /// You can shorten the syntax by: 
        /// using static System.ExecutionContext;
        /// Then you can use ExecCtx directly.
        /// 
        /// Context and ExecCtx are the same, it's only matters of naming preference.
        /// ExecCtx may be better naming when having 'using static System.ExecutionContext'
        /// </summary>
        public static ExecutionContext ExecCtx { get => _default.Value; set => _default.Value = value; }

        #endregion // ExecCtx

        #region Set // static

        /// <summary>
        /// Sets the context value.
        /// </summary>
        /// <param name="deployEnvironment">The deploy environment.</param>
        /// <param name="tenant">The tenant.</param>
        /// <returns></returns>
        public static ExecutionContext Set(
            string deployEnvironment,
            string tenant)
        {
            return Set<object?>(deployEnvironment, tenant, null);
        }

        /// <summary>
        /// Sets the context value.
        /// </summary>
        /// <param name="deployEnvironment">The deploy environment.</param>
        /// <param name="tenant">The tenant.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="containerName">The container identifier.</param>
        /// <param name="containerImage">The container image.</param>
        /// <returns></returns>
        public static ExecutionContext Set<TCorrelation>(
            string deployEnvironment,
            string tenant,
            TCorrelation correlationToken,
            string? processName = null,
            string containerName = "",
            string containerImage = "")
        {
            var context = new ExecutionContext(
                deployEnvironment,
                tenant,
                correlationToken?.ToString() ?? Guid.NewGuid().ToString("D"),
                processName,
                containerName,
                containerImage);
            _default.Value = context;
            return context;
        }

        #endregion // Set // static

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionContext" /> class.
        /// </summary>
        /// <param name="deployEnvironment">The deploy environment.</param>
        /// <param name="tenant">The tenant.</param>
        /// <param name="correlationToken">The correlation token.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="containerName">The container identifier.</param>
        /// <param name="containerImage">The container image.</param>
        private ExecutionContext(
            string deployEnvironment,
            string tenant,
            string correlationToken,
            string? processName = null,
            string containerName = "",
            string containerImage = "")
        {
            DeployEnvironment = deployEnvironment;
            Tenant = tenant;
            CorrelationToken = correlationToken;
            ProcessName = processName ?? Process.GetCurrentProcess().ProcessName;
            ContainerName = containerName;
            ContainerImage = containerImage;
        }

        #endregion // Ctor

        #region DeployEnvironment

        /// <summary>
        /// Gets or sets the deploy environment (DEV, STAGING, PROD and alike).
        /// </summary>
        /// <value>
        /// The deploy environment.
        /// </value>
        public string DeployEnvironment { get; } = string.Empty;

        #endregion // DeployEnvironment

        #region Tenant

        /// <summary>
        /// Gets the tenant (useful in multi-tenant environment).
        /// </summary>
        /// <value>
        /// The tenant.
        /// </value>
        public string Tenant { get; } = string.Empty;

        #endregion // Tenant

        #region CorrelationToken

        /// <summary>
        /// Gets the correlation token.
        /// </summary>
        /// <value>
        /// The correlation token.
        /// </value>
        public string CorrelationToken { get; } = string.Empty;

        #endregion // CorrelationToken

        #region ProcessName

        /// <summary>
        /// Gets the name of the process.
        /// </summary>
        /// <value>
        /// The name of the process.
        /// </value>
        public string ProcessName { get; } = string.Empty;

        #endregion // ProcessName

        #region ContainerName

        /// <summary>
        /// Gets the name of the container (in containerized environment).
        /// </summary>
        /// <value>
        /// The name of the container.
        /// </value>
        public string ContainerName { get; } = string.Empty;

        #endregion // ContainerName

        #region ContainerImage
        
        /// <summary>
        /// Gets the container image (in containerized environment).
        /// </summary>
        /// <value>
        /// The container image.
        /// </value>
        public string ContainerImage { get; } = string.Empty;

        #endregion // ContainerImage

        #region Deconstruct

        /// <summary>
        /// Enable the de-construct functionality.
        /// </summary>
        /// <param name="deployEnvironment">The deploy environment.</param>
        /// <param name="tenant">The tenant.</param>
        public void Deconstruct(
            out string deployEnvironment,
            out string tenant)
        {
            deployEnvironment = DeployEnvironment;
            tenant = Tenant;
        }

        /// <summary>
        /// Enable the de-construct functionality.
        /// </summary>
        /// <param name="deployEnvironment">The deploy environment.</param>
        /// <param name="tenant">The tenant.</param>
        /// <param name="correlationToken">The correlation token.</param>
        public void Deconstruct(
            out string deployEnvironment,
            out string tenant,
            out string correlationToken)
        {
            deployEnvironment = DeployEnvironment;
            tenant = Tenant;
            correlationToken = CorrelationToken;
        }

        /// <summary>
        /// Enable the de-construct functionality.
        /// </summary>
        /// <param name="deployEnvironment">The deploy environment.</param>
        /// <param name="tenant">The tenant.</param>
        /// <param name="correlationToken">The correlation token.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="containerName">Name of the container.</param>
        /// <param name="containerImage">The container image.</param>
        public void Deconstruct(
            out string deployEnvironment,
            out string tenant,
            out string correlationToken,
            out string processName,
            out string containerName,
            out string containerImage)
        {
            deployEnvironment = DeployEnvironment;
            tenant = Tenant;
            correlationToken = CorrelationToken;
            processName = ProcessName;
            containerName = ContainerName;
            containerImage = ContainerImage;
        }
        #endregion // Deconstruct

        #region ToDictionary

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                [nameof(DeployEnvironment)] = DeployEnvironment,
                [nameof(Tenant)] = Tenant,
                [nameof(CorrelationToken)] = CorrelationToken,
                [nameof(ProcessName)] = ProcessName,
                [nameof(ContainerImage)] = ContainerImage,
                [nameof(ContainerName)] = ContainerName,
            };
        }

        #endregion // ToDictionary

        #region Cast Overloads

        /// <summary>
        /// Performs an implicit conversion from <see cref="ExecutionContext"/> to <see cref="IDictionary{System.String, System.Object}"/>.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Dictionary<string, object>(ExecutionContext ctx)
        {
            return (Dictionary<string, object>)ctx.ToDictionary();
        }

        #endregion // Cast Overloads

        #region ToString

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $@"
    Environment: {DeployEnvironment}, Tenant: {Tenant}, 
    ProcessName: {ProcessName}, 
    Container: Name={ContainerName}, Image={ContainerImage}
";
        } 

        #endregion // ToString
    }
}
