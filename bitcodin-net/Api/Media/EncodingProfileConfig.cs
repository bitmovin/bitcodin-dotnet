#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Media
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    public class EncodingProfileConfig
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "videoStreamConfigs")]
        public List<VideoStreamConfig> VideoStreamConfigs { get; set; }

        [JsonProperty(PropertyName = "audioStreamConfigs")]
        public List<AudioStreamConfig> AudioStreamConfigs { get; set; }

        [JsonProperty(PropertyName = "rotation")]
        public int Rotation { get; set; }

        [JsonProperty(PropertyName = "watermarkConfig", NullValueHandling = NullValueHandling.Ignore)]
        public WatermarkConfig WatermarkConfig { get; set; }

        [JsonProperty(PropertyName = "croppingConfig", NullValueHandling = NullValueHandling.Ignore)]
        public CroppingConfig CroppingConfig { get; set; }

        [JsonProperty(PropertyName = "segmentLength")]
        public int SegmentLength { get; set; }

        public EncodingProfileConfig()
        {
            VideoStreamConfigs = new List<VideoStreamConfig>();
            AudioStreamConfigs = new List<AudioStreamConfig>();
            Rotation = 0;
            SegmentLength = 4;
        }
    }
}