#region

using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Media
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class WatermarkConfig
    {
        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "top")]
        public int? Top { get; set; }

        [JsonProperty(PropertyName = "bottom")]
        public int? Bottom { get; set; }

        [JsonProperty(PropertyName = "left")]
        public int? Left { get; set; }

        [JsonProperty(PropertyName = "right")]
        public int? Right { get; set; }
    }
}