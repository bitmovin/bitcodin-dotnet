#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Output
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class OutputList
    {
        [JsonProperty(PropertyName = "totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty(PropertyName = "outputs")]
        public List<Output> Outputs { get; set; }
    }
}