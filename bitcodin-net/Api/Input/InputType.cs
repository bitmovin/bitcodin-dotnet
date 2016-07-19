#region

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

#endregion

namespace com.bitmovin.bitcodin.Api.Input
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum InputType
    {
        [EnumMember(Value = "abs")] Abs,
        [EnumMember(Value = "url")] Url,
        [EnumMember(Value = "ftp")] Ftp,
        [EnumMember(Value = "gcs")] Gcs,
        [EnumMember(Value = "aspera")] Aspera,
        [EnumMember(Value = "s3")] S3
    }
}