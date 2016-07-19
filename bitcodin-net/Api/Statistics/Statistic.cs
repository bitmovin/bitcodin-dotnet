#region

using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Statistics
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class Statistic
    {
        [JsonProperty(PropertyName = "averageDurationInSeconds")]
        public double AverageDurationInSeconds { get; set; }

        [JsonProperty(PropertyName = "jobsFinished")]
        public int JobsFinished { get; set; }

        [JsonProperty(PropertyName = "durationAllInSeconds")]
        public int DurationAllInSeconds { get; set; }

        [JsonProperty(PropertyName = "allJobs")]
        public int AllJobs { get; set; }

        [JsonProperty(PropertyName = "jobsUnfinished")]
        public int JobsUnfinished { get; set; }

        [JsonProperty(PropertyName = "workloadPercentage")]
        public double WorkloadPercentage { get; set; }

        [JsonProperty(PropertyName = "timeWindowInSeconds")]
        public int TimeWindowInSeconds { get; set; }

        [JsonProperty(PropertyName = "enqueueDuration")]
        public int EnqueueDuration { get; set; }

        [JsonProperty(PropertyName = "averageEnqueueDuration")]
        public double AverageEnqueueDuration { get; set; }
    }
}