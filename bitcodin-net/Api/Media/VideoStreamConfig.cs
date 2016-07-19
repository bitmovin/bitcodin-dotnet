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
    public class VideoStreamConfig
    {
        [JsonProperty(PropertyName = "defaultStreamId")]
        public int DefaultStreamId { get; set; }

        [JsonProperty(PropertyName = "bitrate")]
        public long Bitrate { get; set; }

        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        [JsonProperty(PropertyName = "profile")]
        public Profile Profile { get; set; }

        [JsonProperty(PropertyName = "preset")]
        public Preset Preset { get; set; }

        [JsonProperty(PropertyName = "codec")]
        public VideoCodec Codec { get; set; }

        [JsonProperty(PropertyName = "rate")]
        public int Rate { get; set; }
    }
}