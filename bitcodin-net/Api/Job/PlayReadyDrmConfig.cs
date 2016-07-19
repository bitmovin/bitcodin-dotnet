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
    public class PlayReadyDrmConfig : AbstractDrmConfig
    {
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "keySeed")]
        public string KeySeed { get; set; }

        [JsonProperty(PropertyName = "laUrl")]
        public string LaUrl { get; set; }

        [JsonProperty(PropertyName = "kid")]
        public string Kid { get; set; }

        public PlayReadyDrmConfig()
        {
            System = DrmSystem.Playready;
            Method = DrmMethod.MpegCenc;
        }
    }
}