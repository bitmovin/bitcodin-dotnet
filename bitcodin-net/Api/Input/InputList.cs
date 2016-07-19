#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Input
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class InputList
    {
        [JsonProperty(PropertyName = "totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty(PropertyName = "inputs")]
        public List<Input> Inputs { get; set; }
    }
}