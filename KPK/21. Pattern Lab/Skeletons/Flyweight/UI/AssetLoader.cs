using System.Collections.Generic;

namespace ReaperInvasion.UI
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public sealed class AssetLoader
    {
        private static readonly AssetLoader instance = new AssetLoader();
        private IDictionary<AssetType, ImageSource> assetImages;

        private AssetLoader()
        {
            this.assetImages = new Dictionary<AssetType, ImageSource>();
        }

        public static AssetLoader Instance
        {
            get
            {
                return instance;
            }
        }

        public Image GetImage(AssetType type)
        {
            return new Image()
            {
                Source = this.LoadImage(type)
            };
        }

        private ImageSource LoadImage(AssetType type)
        {
            string path = string.Empty;

            switch (type)
            {
                case AssetType.Reaper:
                    path = AssetPaths.ReaperImage;
                    break;
                default:
                    throw new ArgumentException("Unsupported asset type.");
            }

            var src = new Uri(path, UriKind.Relative);

            if (!this.assetImages.ContainsKey(type))
            {
                this.assetImages[type] = BitmapFrame.Create(src);
            }

            return this.assetImages[type];
        }
    }
}
