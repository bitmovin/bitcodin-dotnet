﻿#region

using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Thumbnail
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class SpriteConfig
    {
        [JsonProperty(PropertyName = "jobId")]
        public int JobId { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "distance")]
        public int Distance { get; set; }

        [JsonProperty(PropertyName = "async")]
        public bool Async { get; set; }
    }
}