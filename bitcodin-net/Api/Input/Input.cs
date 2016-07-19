#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using com.bitmovin.bitcodin.Api.Media;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Input
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class Input
    {
        [JsonProperty(PropertyName = "inputId")]
        public int InputId { get; set; }

        [JsonProperty(PropertyName = "filename")]
        public string Filename { get; set; }

        [JsonProperty(PropertyName = "thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty(PropertyName = "iInputType")]
        public InputType InputType { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "mediaConfigurations")]
        public List<Stream> MediaConfigurations { get; set; }
    }
}