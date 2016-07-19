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
    public class VttMpdConfig
    {
        [JsonProperty(PropertyName = "jobId")]
        public int JobId { get; set; }

        [JsonProperty(PropertyName = "subtitles")]
        public VttSubtitle[] Subtitles { get; set; }

        [JsonProperty(PropertyName = "outputFileName")]
        public string OutputFileName { get; set; }
    }
}