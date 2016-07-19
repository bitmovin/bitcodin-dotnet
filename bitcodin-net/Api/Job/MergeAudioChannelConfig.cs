#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Job
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class MergeAudioChannelConfig
    {
        [JsonProperty(PropertyName = "audioChannels")]
        public List<int> AudioChannels { get; set; }

        public MergeAudioChannelConfig(List<int> audioChannels)
        {
            AudioChannels = audioChannels;
        }
    }
}