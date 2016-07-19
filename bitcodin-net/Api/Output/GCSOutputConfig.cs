#region

using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Output
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class GcsOutputConfig
    {
        [JsonProperty(PropertyName = "type")]
        public OutputType Type { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "accessKey")]
        public string AccessKey { get; set; }

        [JsonProperty(PropertyName = "secretKey")]
        public string SecretKey { get; set; }

        [JsonProperty(PropertyName = "bucket")]
        public string Bucket { get; set; }

        [JsonProperty(PropertyName = "prefix")]
        public string Prefix { get; set; }

        [JsonProperty(PropertyName = "makePublic")]
        public bool MakePublic { get; set; }

        public GcsOutputConfig()
        {
            Type = OutputType.Gcs;
            Prefix = "";
            MakePublic = true;
        }
    }
}