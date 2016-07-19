#region

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

#endregion

namespace com.bitmovin.bitcodin.Api.Media
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum Profile
    {
        [EnumMember(Value = "Baseline")] Baseline,
        [EnumMember(Value = "Main")] Main,
        [EnumMember(Value = "High")] High
    }
}