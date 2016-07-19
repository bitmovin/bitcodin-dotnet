#region

using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Thumbnail
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class Sprite
    {
        [JsonProperty(PropertyName = "vttUrl")]
        public string VttUrl { get; set; }

        [JsonProperty(PropertyName = "spriteUrl")]
        public string SpriteUrl { get; set; }
    }
}