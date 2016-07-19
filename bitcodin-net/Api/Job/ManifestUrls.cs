#region

using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Job
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class ManifestUrls
    {
        [JsonProperty(PropertyName = "mpdUrl")]
        public string MpdUrl { get; set; }

        [JsonProperty(PropertyName = "m3u8Url")]
        public string M3U8Url { get; set; }
    }
}