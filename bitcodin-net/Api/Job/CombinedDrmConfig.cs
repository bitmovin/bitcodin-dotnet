#region

using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Job
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class CombinedDrmConfig : AbstractDrmConfig
    {
        [JsonProperty(PropertyName = "kid")]
        public string KId { get; set; }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "laUrl")]
        public string LaUrl { get; set; }

        [JsonProperty(PropertyName = "pssh")]
        public string Pssh { get; set; }

        public CombinedDrmConfig()
        {
            Method = DrmMethod.MpegCenc;
            System = DrmSystem.WidevinePlayready;
        }
    }
}