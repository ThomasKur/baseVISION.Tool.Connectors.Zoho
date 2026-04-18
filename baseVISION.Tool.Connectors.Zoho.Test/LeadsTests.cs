using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baseVISION.Tool.Connectors.Zoho.Test
{
    [TestClass]
    public class LeadsTests : TestBase
    {
        [TestMethod]
        public void Leads_List_ReturnsResults()
        {
            var result = ZohoClient.Leads.List();

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod]
        public void Leads_List_Page2_ReturnsResults()
        {
            var page1 = ZohoClient.Leads.List(page: 1);
            Assert.IsNotNull(page1, "Page 1 should exist");

            if (!page1.Info.MoreRecords)
            {
                Assert.Inconclusive("Page 2 does not exist - not enough leads in the system to test pagination (MoreRecords=false).");
                return;
            }

            var result = ZohoClient.Leads.List(page: 2);
            Assert.IsNotNull(result, "Page 2 should exist when MoreRecords is true");
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public void Leads_Get_ReturnsRecord()
        {
            var list = ZohoClient.Leads.List();
            Assert.IsNotNull(list.Data);
            Assert.IsTrue(list.Data.Count > 0);

            var firstId = list.Data[0].Id;
            var result = ZohoClient.Leads.Get(firstId);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Count > 0);
            Assert.AreEqual(firstId, result.Data[0].Id);
        }
    }
}
