using Arvefordeleren_ClassLibrary.Models;
using Arvefordeleren_ClassLibrary.Services;
namespace UnitTest
{
    [TestClass]
    public sealed class AssetAPITest
    {
        AssetService _assetService;
        Asset asset;

        [TestInitialize]
        public void Initialize() // Arrange
        {
            _assetService = new AssetService();
            asset = new Asset(){Name = "Rolex", SeparateEstate = "Markus" };
        }
        [TestMethod]
        public async Task AddAndRetrieve_Asset_ThroughAssetService()
        {
            // Act
            await _assetService.Create(asset); 
            Asset retrievedAsset = await _assetService.GetById(asset.Id);

            // Assert
            Assert.AreEqual(asset.Id, retrievedAsset.Id);

            // Clean Up
            await _assetService.Delete(asset.Id);
        }
        [TestMethod]
        public async Task Update_Asset_ThroughAssetService()
        {
            // Act
            await _assetService.Create(asset); 
            asset.SeparateEstate = "Sophie";
            await _assetService.Update(asset);
            Asset retrievedAsset = await _assetService.GetById(asset.Id);

            // Assert
            Assert.AreEqual("Sophie", retrievedAsset.SeparateEstate);

            // Clean Up
            await _assetService.Delete(asset.Id);
        }
        [TestMethod]
        public async Task Delete_Asset_ThroughAssetService()
        {
            // Act
            await _assetService.Create(asset);
            await _assetService.Delete(asset.Id);
            Asset retrievedAsset = null;

            // Assert
            try
            {
                retrievedAsset = await _assetService.GetById(asset.Id);
            }
            catch (HttpRequestException ex)
            {
                Assert.IsTrue(ex.Message.Contains("500"), "Expected a 500 Internal Server Error after deletion.");
            }
            finally
            {
                Assert.IsNull(retrievedAsset);
            }
        }
    }
}
