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
    public class HlsEncryptionConfig
    {
        [JsonProperty(PropertyName = "method")]
        public HlsMethod Method { get; set; }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "iv")]
        public string Iv { get; set; }

        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }
    }
}