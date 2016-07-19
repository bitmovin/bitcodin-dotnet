#region

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

#endregion

namespace com.bitmovin.bitcodin.Api.Job
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum Speed
    {
        [EnumMember(Value = "standard")] Standard,
        [EnumMember(Value = "premium")] Premium
    }
}