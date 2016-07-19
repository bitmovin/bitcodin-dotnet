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
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    public abstract class AbstractDrmConfig
    {
        [JsonProperty(PropertyName = "system")]
        public DrmSystem System { get; set; }

        [JsonProperty(PropertyName = "method")]
        public DrmMethod Method { get; set; }
    }
}