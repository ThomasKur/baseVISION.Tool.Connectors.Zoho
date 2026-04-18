using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baseVISION.Tool.Connectors.Zoho.Test
{
    [TestClass]
    public class RecurringsTests : TestBase
    {
        [TestMethod]
        public void Recurrings_List_ReturnsResults()
        {
            var result = ZohoClient.Recurrings.List(sortBy: "Name");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod]
        public void Recurrings_List_Page2_ReturnsResults()
        {
            var page1 = ZohoClient.Recurrings.List(page: 1, sortBy: "Name");
            Assert.IsNotNull(page1, "Page 1 should exist");

            if (!page1.Info.MoreRecords)
            {
                Assert.Inconclusive("Page 2 does not exist - not enough recurrings in the system to test pagination (MoreRecords=false).");
                return;
            }

            var result = ZohoClient.Recurrings.List(page: 2, sortBy: "Name");
            Assert.IsNotNull(result, "Page 2 should exist when MoreRecords is true");
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public void Recurrings_Get_ReturnsRecord()
        {
            var list = ZohoClient.Recurrings.List(sortBy: "Name");
            Assert.IsNotNull(list.Data);
            Assert.IsTrue(list.Data.Count > 0);

            var firstId = list.Data[0].Id;
            var result = ZohoClient.Recurrings.Get(firstId);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Count > 0);
            Assert.AreEqual(firstId, result.Data[0].Id);
        }
    }
}
