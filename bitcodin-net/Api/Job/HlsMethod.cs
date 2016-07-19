#region

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

#endregion

namespace com.bitmovin.bitcodin.Api.Job
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum HlsMethod
    {
        [EnumMember(Value = "SAMPLE-AES")] SampleAes,
        [EnumMember(Value = "FAIRPLAY")] Fairplay,
        [EnumMember(Value = "AES-128")] Aes128
    }
}