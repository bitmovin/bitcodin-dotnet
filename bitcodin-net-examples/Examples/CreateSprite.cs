#region

using System.Diagnostics;
using com.bitmovin.bitcodin.Api;
using com.bitmovin.bitcodin.Api.Thumbnail;

#endregion

namespace com.bitmovin.bitcodin.examples.Examples
{
    public static class CreateSprite
    {
        public static void Run()
        {
            /* Create BitcodinApi */
            const string apiKey = "YOUR_API_KEY";
            var bitApi = new BitcodinApi(apiKey);

            var spriteConfig = new SpriteConfig
            {
                //insert your jobID
                JobId = 312840,
                Height = 90,
                Width = 120,
                Distance = 10,
                Async = true
            };

            var sprite = bitApi.CreateSprite(spriteConfig);

            Debug.WriteLine("Thumbnail URL: " + sprite.SpriteUrl);
            Debug.WriteLine("Thumbnail VTT URL: " + sprite.VttUrl);
        }
    }
}