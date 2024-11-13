using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Models
{
    public static class Testament
    {
        private static List<Asset> assets { get; set; } = new List<Asset>();
        private static int assetCount = 0;
        public static void AddAsset(Asset asset)
        {
            asset.id = assetCount++;
            assets.Add(asset);
        }
        public static List<Asset> GetAssets() => assets;
        public static void UpdateAsset()
        {
            assets.Find
        }
    }
}
