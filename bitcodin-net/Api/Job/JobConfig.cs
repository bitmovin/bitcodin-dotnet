#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Job
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class JobConfig
    {
        [JsonProperty(PropertyName = "inputId")]
        public int InputId { get; set; }

        [JsonProperty(PropertyName = "outputId", NullValueHandling = NullValueHandling.Ignore)]
        public int OutputId { get; set; }

        [JsonProperty(PropertyName = "startTime", NullValueHandling = NullValueHandling.Ignore)]
        public int StartTime { get; set; }

        [JsonProperty(PropertyName = "encodingProfileId", NullValueHandling = NullValueHandling.Ignore)]
        public int EncodingProfileId { get; set; }

        [JsonProperty(PropertyName = "manifestTypes", NullValueHandling = NullValueHandling.Ignore)]
        public List<ManifestType> ManifestTypes { get; set; }

        [JsonProperty(PropertyName = "extractClosedCaptions", NullValueHandling = NullValueHandling.Ignore)]
        public bool ExtractClosedCaptions { get; set; }

        [JsonProperty(PropertyName = "deinterlace", NullValueHandling = NullValueHandling.Ignore)]
        public bool Deinterlace { get; set; }

        [JsonProperty(PropertyName = "speed", NullValueHandling = NullValueHandling.Ignore)]
        public Speed Speed { get; set; }

        [JsonProperty(PropertyName = "hlsEncryptionConfig", NullValueHandling = NullValueHandling.Ignore)]
        public HlsEncryptionConfig HlsEncryptionConfig { get; set; }

        [JsonProperty(PropertyName = "mergeAudioChannelConfigs", NullValueHandling = NullValueHandling.Ignore)]
        public MergeAudioChannelConfig[] MergeAudioChannelConfigs { get; set; }

        [JsonProperty(PropertyName = "videoMetaData", NullValueHandling = NullValueHandling.Ignore)]
        public VideoMetaData[] VideoMetaData { get; set; }

        [JsonProperty(PropertyName = "audioMetaData", NullValueHandling = NullValueHandling.Ignore)]
        public AudioMetaData[] AudioMetaData { get; set; }

        [JsonProperty(PropertyName = "drmConfig", NullValueHandling = NullValueHandling.Ignore)]
        public AbstractDrmConfig DrmConfig { get; set; }


        public JobConfig()
        {
            ManifestTypes = new List<ManifestType>();
        }
    }
}