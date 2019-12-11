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
    public class ExecutionContext
    {
        private static readonly AsyncLocal<ExecutionContext> _default = new AsyncLocal<ExecutionContext>();

        #region Value

        /// <summary>
        /// Gets or sets the context value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public static ExecutionContext Value { get => _default.Value; set => _default.Value = value; }

        #endregion // Value

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
    }

}
