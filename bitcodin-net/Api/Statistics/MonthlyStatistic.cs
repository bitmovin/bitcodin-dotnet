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
    public class MonthlyStatistic
    {
        [JsonProperty(PropertyName = "jobCountFinished")]
        public int JobCountFinished { get; set; }

        [JsonProperty(PropertyName = "realtimeFactor")]
        public double RealtimeFactor { get; set; }

        [JsonProperty(PropertyName = "totalBytesWritten")]
        public long TotalBytesWritten { get; set; }

        [JsonProperty(PropertyName = "avgBytesWritten")]
        public long AvgBytesWritten { get; set; }

        [JsonProperty(PropertyName = "totalTimeEnqueued")]
        public long TotalTimeEnqueued { get; set; }

        [JsonProperty(PropertyName = "avgTimeEnqueued")]
        public long AvgTimeEnqueued { get; set; }

        [JsonProperty(PropertyName = "totalTimeEncoded")]
        public long TotalTimeEncoded { get; set; }

        [JsonProperty(PropertyName = "avgTimeEncoded")]
        public long AvgTimeEncoded { get; set; }

        [JsonProperty(PropertyName = "totalTime")]
        public long TotalTime { get; set; }

        [JsonProperty(PropertyName = "avgJobTime")]
        public long AvgJobTime { get; set; }
    }
}