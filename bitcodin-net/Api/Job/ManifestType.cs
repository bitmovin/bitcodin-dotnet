#region

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

#endregion

namespace com.bitmovin.bitcodin.Api.Job
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum ManifestType
    {
        [EnumMember(Value = "mpd")] MpegDashMpd,
        [EnumMember(Value = "m3u8")] HlsM3U8
    }
}