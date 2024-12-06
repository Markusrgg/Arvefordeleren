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
            Asset copyedReferenceToAsset = asset;
            Asset cloneOfAsset = asset.Clone();
            asset.Name = "Simon";

            // Since unmodifiedAsset got the reference to the objekt from asset,
            // they should both point to the same objekt and be equel, even when only one of them is modified.
            Assert.AreEqual(asset.Name, copyedReferenceToAsset.Name);

            // The clone should be seperate from the original asset,
            // as the objekt itself was cloned, instead of the path being passed along.
            Assert.AreNotEqual(cloneOfAsset.Name, asset.Name);
        }

          
    }
}
