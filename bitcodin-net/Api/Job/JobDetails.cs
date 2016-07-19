#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using com.bitmovin.bitcodin.Api.Media;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Job
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class JobDetails
    {
        [JsonProperty(PropertyName = "jobId")]
        public int JobId { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string JobStatus { get; set; }

        [JsonProperty(PropertyName = "frameRate")]
        public double FrameRate { get; set; }

        [JsonProperty(PropertyName = "segmentsSplitted")]
        public int SegmentsSplitted { get; set; }

        [JsonProperty(PropertyName = "totalFramesWritten")]
        public double TotalFramesWritten { get; set; }

        [JsonProperty(PropertyName = "bytesWritten")]
        public long BytesWritten { get; set; }

        [JsonProperty(PropertyName = "jobFolder")]
        public string JobFolder { get; set; }

        [JsonProperty(PropertyName = "input")]
        public Input.Input Input { get; set; }

        [JsonProperty(PropertyName = "encodingProfiles")]
        public List<EncodingProfile> EncodingProfiles { get; set; }

        [JsonProperty(PropertyName = "statusDescription")]
        public string StatusDescription { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "encodedDuration")]
        public int EncodedDuration { get; set; }

        [JsonProperty(PropertyName = "enqueueDuration")]
        public int EnqueueDuration { get; set; }

        [JsonProperty(PropertyName = "realtimeFactor")]
        public double RealtimeFactor { get; set; }

        [JsonProperty(PropertyName = "manifestUrls")]
        public ManifestUrls ManifestUrls { get; set; }
    }
}