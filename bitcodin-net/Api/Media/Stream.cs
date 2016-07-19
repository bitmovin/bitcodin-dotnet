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
    public class Stream
    {
        [JsonProperty(PropertyName = "streamId")]
        public int StreamId { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public long Duration { get; set; }

        [JsonProperty(PropertyName = "rate")]
        public double Rate { get; set; }

        [JsonProperty(PropertyName = "xodec")]
        public string Codec { get; set; }

        [JsonProperty(PropertyName = "zype")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "bitrate")]
        public long Bitrate { get; set; }

        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        [JsonProperty(PropertyName = "pixelFormat")]
        public string PixelFormat { get; set; }

        [JsonProperty(PropertyName = "sampleAspectRatioNum")]
        public int SampleAspectRatioNum { get; set; }

        [JsonProperty(PropertyName = "sampleAspectRatioDen")]
        public int SampleAspectRatioDen { get; set; }

        [JsonProperty(PropertyName = "displayAspectRatioNum")]
        public int DisplayAspectRatioNum { get; set; }

        [JsonProperty(PropertyName = "displayAspectRatioDen")]
        public int DisplayAspectRatioDen { get; set; }

        [JsonProperty(PropertyName = "sampleFormat")]
        public int SampleFormat { get; set; }

        [JsonProperty(PropertyName = "channelFormat")]
        public string ChannelFormat { get; set; }
    }
}