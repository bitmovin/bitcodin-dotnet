#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Job
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class JobList
    {
        [JsonProperty(PropertyName = "totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty(PropertyName = "perPage")]
        public long PerPage { get; set; }

        [JsonProperty(PropertyName = "jobs")]
        public List<JobDetails> Jobs { get; set; }
    }
}