#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Media
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class EncodingProfileList
    {
        [JsonProperty(PropertyName = "totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty(PropertyName = "profiles")]
        public List<EncodingProfile> Profiles { get; set; }
    }
}