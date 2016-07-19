#region

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

#endregion

namespace com.bitmovin.bitcodin.Api.Media
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum VideoCodec
    {
        [EnumMember(Value = "h264")] H264,
        [EnumMember(Value = "hevc")] Hevc
    }
}