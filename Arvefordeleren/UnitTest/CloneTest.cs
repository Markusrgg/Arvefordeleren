using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arvefordeleren_ClassLibrary.Services;
using Arvefordeleren_ClassLibrary.Models;


namespace UnitTestAPI
{
    [TestClass]
    public sealed class CloneTest
    {
        private Asset asset;
        [TestInitialize]
        public void Initialize() // Arrange
        {
            asset = new Asset { Name="Markus", SeparateEstate="Rolex"};
        }
        [TestMethod]
        public void Clone_Asset_ThroughModel()
        {
            Asset unmodifiedAsset = asset;
            Asset clone = asset.Clone();
            asset.Name = "Simon";
            Assert.AreEqual(asset.Name, unmodifiedAsset.Name);
            Assert.AreNotEqual(clone.Name, asset.Name);
        }

          
    }
}
