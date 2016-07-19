#region

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

#endregion

namespace com.bitmovin.bitcodin.Api.Media
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum Preset
    {
        [EnumMember(Value = "Standard")] Standard,
        [EnumMember(Value = "Professional")] Professional,
        [EnumMember(Value = "Premium")] Premium
    }
}