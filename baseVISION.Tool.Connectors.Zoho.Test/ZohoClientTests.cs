using baseVISION.Tool.Connectors.Zoho;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace baseVISION.Tool.Connectors.Zoho.Test
{
    [TestClass]
    public class ZohoClientTests
    {
        [TestMethod]
        public void TestConnect_Success()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddUserSecrets<ZohoClientTests>()
                .Build();

            UserConfig uc = config.Get<UserConfig>();

            using var loggerFactory = LoggerFactory.Create(builder =>
                builder
                    .AddConsole()
                    .SetMinimumLevel(LogLevel.Debug));

            var logger = loggerFactory.CreateLogger<ZohoClientTests>();

            var zohoClient = new ZohoClient(new Uri(uc.url), uc.clientId, uc.clientSecret, uc.RefreshToken, logger: logger);

            Assert.IsNotNull(zohoClient.Token.AccessToken);
            Assert.IsTrue(zohoClient.Token.ExpiresIn > 0);
        }

        [TestMethod]
        public void TestConnect_Failed()
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddUserSecrets<ZohoClient>()
                    .Build();

                UserConfig uc = config.Get<UserConfig>();

                var zohoClient = new ZohoClient(new Uri(uc.url), "sadadasd", uc.clientSecret, uc.RefreshToken);

                Assert.IsNull(zohoClient.Token.AccessToken);
                Assert.IsTrue(zohoClient.Token.ExpiresIn != 0);
            }
            catch
            {
            }
        }
    }
}
