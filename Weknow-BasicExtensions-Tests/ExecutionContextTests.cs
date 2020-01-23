using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;
using static System.ExecutionContext;

namespace Weknow_BasicExtensions_Tests
{
    public class ExecutionContextTests
    {
        [Theory]
        [InlineData("Dev", "Org1", "#11111")]
        [InlineData("Dev", "Org2", "@etd")]
        [InlineData("Prod", "Org3", null)]
        [InlineData("Prod", "Org3", 48)]
        public async Task ExecutionContextTest_SucceedAsync(string env, string tenant, object correlation )
        {
            ExecutionContext expected = ExecutionContext.Set(env, tenant, correlation
, containerName: "X", containerImage: "Y");


            ExecutionContext context = await Step1Async().ConfigureAwait(false);
            Assert.Equal(expected, context);

            var (deployEnvironment, theTenant, correlationToken, processName, containerName, containerImage) = context;
            Assert.Equal(expected.DeployEnvironment, deployEnvironment);
            Assert.Equal(env, deployEnvironment);
            Assert.Equal(expected.Tenant, theTenant);
            Assert.Equal(tenant, theTenant);
            Assert.Equal(expected.CorrelationToken, correlationToken);
            Assert.Equal(expected.ProcessName, processName);
            Assert.Equal(Process.GetCurrentProcess().ProcessName, processName);
            Assert.Equal(expected.ContainerName, containerName);
            Assert.Equal(expected.ContainerImage, containerImage);
        }

        [Fact]
        public async Task ExecutionContextWithoutCorrelationTest_SucceedAsync()
        {
            string env = "PROD";
            string tenant = "ORG";

            ExecutionContext expected = ExecutionContext.Set(env, tenant);


            ExecutionContext context = await Step1Async().ConfigureAwait(false);
            Assert.Equal(expected, context);

            var (deployEnvironment, theTenant, correlationToken, processName, containerName, containerImage) = context;
            Assert.Equal(expected.DeployEnvironment, deployEnvironment);
            Assert.Equal(env, deployEnvironment);
            Assert.Equal(expected.Tenant, theTenant);
            Assert.Equal(tenant, theTenant);
            Assert.Equal(expected.CorrelationToken, correlationToken);
            Assert.Equal(expected.ProcessName, processName);
            Assert.Equal(Process.GetCurrentProcess().ProcessName, processName);
            Assert.Equal(expected.ContainerName, containerName);
            Assert.Equal(expected.ContainerImage, containerImage);
        }

        [Fact]
        public async Task ExecutionContextWithGuidTest_SucceedAsync()
        {
            string env = "PROD";
            string tenant = "ORG";
            Guid correlation = Guid.NewGuid();

            ExecutionContext expected = ExecutionContext.Set(env, tenant, correlation
, containerName: "X", containerImage: "Y");


            ExecutionContext context = await Step1Async().ConfigureAwait(false);
            Assert.Equal(expected, context);

            var (deployEnvironment, theTenant, correlationToken, processName, containerName, containerImage) = context;
            Assert.Equal(expected.DeployEnvironment, deployEnvironment);
            Assert.Equal(env, deployEnvironment);
            Assert.Equal(expected.Tenant, theTenant);
            Assert.Equal(tenant, theTenant);
            Assert.Equal(expected.CorrelationToken, correlationToken);
            Assert.Equal(expected.ProcessName, processName);
            Assert.Equal(Process.GetCurrentProcess().ProcessName, processName);
            Assert.Equal(expected.ContainerName, containerName);
            Assert.Equal(expected.ContainerImage, containerImage);
        }

        [Fact]
        public async Task ExecutionContextWithDateTest_SucceedAsync()
        {
            string env = "PROD";
            string tenant = "ORG";
            var correlation = DateTime.Now;

            ExecutionContext expected = ExecutionContext.Set(env, tenant, correlation
, containerName: "X", containerImage: "Y");


            ExecutionContext context = await Step1Async().ConfigureAwait(false);
            Assert.Equal(expected, context);

            var (deployEnvironment, theTenant, correlationToken, processName, containerName, containerImage) = context;
            Assert.Equal(expected.DeployEnvironment, deployEnvironment);
            Assert.Equal(env, deployEnvironment);
            Assert.Equal(expected.Tenant, theTenant);
            Assert.Equal(tenant, theTenant);
            Assert.Equal(expected.CorrelationToken, correlationToken);
            Assert.Equal(expected.ProcessName, processName);
            Assert.Equal(Process.GetCurrentProcess().ProcessName, processName);
            Assert.Equal(expected.ContainerName, containerName);
            Assert.Equal(expected.ContainerImage, containerImage);
        }

        private async Task<ExecutionContext> Step1Async()
        {
            await Task.Delay(2).ConfigureAwait(false);
            ExecutionContext context = await Step2Async().ConfigureAwait(false);
            return context;
        }

        private async Task<ExecutionContext> Step2Async()
        {
            await Task.Delay(2).ConfigureAwait(false);
            ExecutionContext[] contexts = await Task.WhenAll(Step3aAsync(), Step3bAsync()).ConfigureAwait(false);
            Assert.Same(contexts[0], contexts[1]);
            return contexts[0];
        }

        private async Task<ExecutionContext> Step3aAsync()
        {
            await Task.Delay(2).ConfigureAwait(false);
            return ExecutionContext.Context;
        }

        private async Task<ExecutionContext> Step3bAsync()
        {
            await Task.Delay(2).ConfigureAwait(false);
            return ExecCtx;
        }
    }
}
