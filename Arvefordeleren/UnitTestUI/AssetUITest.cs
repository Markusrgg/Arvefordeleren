using Arvefordeleren_ClassLibrary.Models;
using Arvefordeleren_ClassLibrary.Services;
using Arvefordeleren_WebApp.Components.Pages;
using Moq;
namespace UnitTestUI
{
    public class AssetUITest
    {
        private AssetPage assetPage;
        private readonly Mock<AssetService> _assetServiceMock;

        public AssetUITest()
        {
            assetPage = new AssetPage();
            assetService = new AssetService();
            assetPage.assetService

        }

        [Theory]
        [InlineData("Rolex", "Markus")]
        [InlineData("Boat", "Simon")]
        [InlineData("Car", "Rasmus")]
        public async Task AddAndRetrieve_Asset_ThroughAssetPage(string name, string seperateEstate)
        { 
            await assetPage.InitializeForTestingAsync();
            assetPage.asset = new Asset { Name=name, SeparateEstate=seperateEstate};
            await assetPage.UpdateOrCreateAsset();

            Asset retrievedAsset = await assetService.GetById(assetPage.asset.Id);

            Assert.Equal(assetPage.asset, retrievedAsset);
        }
    }
}