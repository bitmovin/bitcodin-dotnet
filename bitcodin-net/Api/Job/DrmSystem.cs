#region

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

#endregion

namespace com.bitmovin.bitcodin.Api.Job
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum DrmSystem
    {
        [EnumMember(Value = "widevine")] Widevine,
        [EnumMember(Value = "playready")] Playready,
        [EnumMember(Value = "widevine_playready")] WidevinePlayready
    }
}