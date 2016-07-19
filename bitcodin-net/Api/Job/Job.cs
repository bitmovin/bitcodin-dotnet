#region

using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Job
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class Job
    {
        [JsonProperty(PropertyName = "jobId")]
        public int JobId { get; set; }

        [JsonProperty(PropertyName = "status")]
        public JobStatus Status { get; set; }
    }
}