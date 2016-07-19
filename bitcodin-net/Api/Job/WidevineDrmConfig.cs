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
    public class WidevineDrmConfig : AbstractDrmConfig
    {
        [JsonProperty(PropertyName = "provider")]
        public string Provider { get; set; }

        [JsonProperty(PropertyName = "signingKey")]
        public string SigningKey { get; set; }

        [JsonProperty(PropertyName = "signingIV")]
        public string SigningIv { get; set; }

        [JsonProperty(PropertyName = "requestUrl")]
        public string RequestUrl { get; set; }

        [JsonProperty(PropertyName = "contentId")]
        public string ContentId { get; set; }

        public WidevineDrmConfig()
        {
            Method = DrmMethod.MpegCenc;
            System = DrmSystem.Widevine;
        }
    }
}