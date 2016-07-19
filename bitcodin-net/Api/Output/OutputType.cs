#region

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

#endregion

namespace com.bitmovin.bitcodin.Api.Output
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum OutputType
    {
        [EnumMember(Value = "s3")] S3,
        [EnumMember(Value = "ftp")] Ftp,
        [EnumMember(Value = "azure")] Azure,
        [EnumMember(Value = "gcs")] Gcs
    }
}