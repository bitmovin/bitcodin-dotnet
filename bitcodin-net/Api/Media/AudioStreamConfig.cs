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
    public class AudioStreamConfig
    {
        [JsonProperty(PropertyName = "defaultStreamId")]
        public int DefaultStreamId { get; set; }

        [JsonProperty(PropertyName = "bitrate")]
        public long Bitrate { get; set; }

        [JsonProperty(PropertyName = "samplerate")]
        public long Samplerate { get; set; }

        [JsonProperty(PropertyName = "rate")]
        public int Rate { get; set; }
    }
}