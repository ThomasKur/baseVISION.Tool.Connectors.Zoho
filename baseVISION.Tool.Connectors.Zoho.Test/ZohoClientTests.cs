using baseVISION.Tool.Connectors.Zoho;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace baseVISION.Tool.Connectors.Zoho.Test
{

    [TestClass]
    public class ZohoClientTests
    {
        private Zoho.ZohoClient zohoClient;
        private void Initialize()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddUserSecrets<ZohoClientTests>()
            .Build();

            UserConfig uc = config.Get<UserConfig>();

            zohoClient = new Zoho.ZohoClient(new Uri(uc.url), uc.clientId, uc.clientSecret, uc.RefreshToken);

        }
        [TestMethod]
        public void TestConnect_Success()
        {
            try
            {
                Initialize();
                Assert.IsNotNull(zohoClient.Token.AccessToken);
                Assert.IsTrue(zohoClient.Token.ExpiresIn > 0);
            } catch
            {
                Assert.Fail();
            }
            
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

                zohoClient = new Zoho.ZohoClient(new Uri(uc.url), "sadadasd", uc.clientSecret, uc.RefreshToken);

                Assert.IsNull(zohoClient.Token.AccessToken);
                Assert.IsTrue(zohoClient.Token.ExpiresIn != 0);
            }
            catch
            {
                
            }

        }

        [TestMethod()]
        public void ListTest()
        {
            Initialize();
            var leads = zohoClient.Leads.List();
            Assert.IsTrue(leads.Data.Count > 0);
            var resourceplan = zohoClient.ResourcePlans.List();
            Assert.IsTrue(resourceplan.Data.Count > 0);
        }
    }
}
