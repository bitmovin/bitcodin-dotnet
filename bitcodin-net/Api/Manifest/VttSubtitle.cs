#region

using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Manifest
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class VttSubtitle
    {
        [JsonProperty(PropertyName = "langShort")]
        public string LangShort { get; set; }

        [JsonProperty(PropertyName = "langLong")]
        public string LangLong { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}