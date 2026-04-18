using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baseVISION.Tool.Connectors.Zoho.Test
{
    [TestClass]
    public class ProductsTests : TestBase
    {
        [TestMethod]
        public void Products_List_ReturnsResults()
        {
            var result = ZohoClient.Products.List(sortBy: "Product_Name");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod]
        public void Products_List_Page2_ReturnsResults()
        {
            var page1 = ZohoClient.Products.List(page: 1, sortBy: "Product_Name");
            Assert.IsNotNull(page1, "Page 1 should exist");

            if (!page1.Info.MoreRecords)
            {
                Assert.Inconclusive("Page 2 does not exist - not enough products in the system to test pagination (MoreRecords=false).");
                return;
            }

            var result = ZohoClient.Products.List(page: 2, sortBy: "Product_Name");
            Assert.IsNotNull(result, "Page 2 should exist when MoreRecords is true");
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public void Products_Get_ReturnsRecord()
        {
            var list = ZohoClient.Products.List(sortBy: "Product_Name");
            Assert.IsNotNull(list.Data);
            Assert.IsTrue(list.Data.Count > 0);

            var firstId = list.Data[0].Id;
            var result = ZohoClient.Products.Get(firstId);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Count > 0);
            Assert.AreEqual(firstId, result.Data[0].Id);
        }
    }
}
