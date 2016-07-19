#region

using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Input
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class GcsInputConfig
    {
        [JsonProperty(PropertyName = "type")]
        public InputType Type { get; set; }

        [JsonProperty(PropertyName = "skipAnalysis")]
        public bool SkipAnalysis { get; set; }

        [JsonProperty(PropertyName = "accessKey")]
        public string AccessKey { get; set; }

        [JsonProperty(PropertyName = "secretKey")]
        public string SecretKey { get; set; }

        [JsonProperty(PropertyName = "bucket")]
        public string Bucket { get; set; }

        [JsonProperty(PropertyName = "objectKey")]
        public string ObjectKey { get; set; }

        public GcsInputConfig()
        {
            Type = InputType.Gcs;
        }
    }
}