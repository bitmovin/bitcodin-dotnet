#region

using System.Diagnostics;
using com.bitmovin.bitcodin.Api;
using com.bitmovin.bitcodin.Api.Thumbnail;

#endregion

namespace com.bitmovin.bitcodin.examples.Examples
{
    public static class CreateThumbnail
    {
        public static void Run()
        {
            /* Create BitcodinApi */
            const string apiKey = "YOUR_API_KEY";
            var bitApi = new BitcodinApi(apiKey);

            var thumbnailConfig = new ThumbnailConfig
            {
                //insert your jobID
                JobId = 312840,
                Height = 320,
                Position = 5,
                Async = true,
                FileName = "filename"
            };

            var thumbnail = bitApi.CreateThumbnail(thumbnailConfig);

            Debug.WriteLine("Thumbnail URL: " + thumbnail.ThumbnailUrl);
        }
    }
}