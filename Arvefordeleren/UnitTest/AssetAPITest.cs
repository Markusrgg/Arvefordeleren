using Arvefordeleren_ClassLibrary.Models;
using Arvefordeleren_ClassLibrary.Services;
namespace UnitTestAPI
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
        // Adds Asset to Repo, then retrieves it and asserts if it matches with original Asset.
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
        // Adds Asset to Repo, Updates SeperateEsate value and then asserts if it was changed correctly.
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
        // Adds Asset to Repo, then Deletes it. Then attempt to retrieve it,
        // handle the errormessage and then assert if it was deleted.
        [TestMethod]
        public async Task Delete_Asset_ThroughAssetService()
        {
            // Act
            await _assetService.Create(asset);
            await _assetService.Delete(asset.Id);
            Asset retrievedAsset = null;
            try
            {
                retrievedAsset = await _assetService.GetById(asset.Id);
            }
            catch (HttpRequestException ex)
            {
                Assert.IsTrue(ex.Message.Contains("500"), "Expected a 500 Internal Server Error after deletion.");
            }
            // Assert
            finally
            {
                Assert.IsNull(retrievedAsset);
            }
        }
    }
}
