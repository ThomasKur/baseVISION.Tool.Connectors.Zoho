using baseVISION.Tool.Connectors.Zoho;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace baseVISION.Tool.Connectors.Zoho.Test
{
    [TestClass]
    public class AssemblyInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddUserSecrets<ZohoClientTests>()
                .Build();

            UserConfig uc = config.Get<UserConfig>();

            TestBase.LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
                builder
                    .AddConsole()
                    .SetMinimumLevel(LogLevel.Debug));

            TestBase.Logger = TestBase.LoggerFactory.CreateLogger<TestBase>();

            TestBase.ZohoClient = new ZohoClient(new Uri(uc.url), uc.clientId, uc.clientSecret, uc.RefreshToken, logger: TestBase.Logger);

            TestBase.Logger?.LogInformation("Test assembly initialized with shared ZohoClient. Token will be reused across all tests.");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            TestBase.LoggerFactory?.Dispose();
        }
    }

    public abstract class TestBase
    {
        private const int ThrottleDelayMs = 10000;

        internal static ZohoClient ZohoClient { get; set; }
        internal static ILogger Logger { get; set; }
        internal static ILoggerFactory LoggerFactory { get; set; }

        [TestCleanup]
        public void Cleanup()
        {
            Logger?.LogDebug("Waiting {DelayMs}ms after test to avoid API throttling.", ThrottleDelayMs);
            Thread.Sleep(ThrottleDelayMs);
        }
    }
}
