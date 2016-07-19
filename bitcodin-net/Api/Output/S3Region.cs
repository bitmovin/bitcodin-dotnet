#region

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

#endregion

namespace com.bitmovin.bitcodin.Api.Output
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum S3Region
    {
        [EnumMember(Value = "eu-west-1")] EuWest1,
        [EnumMember(Value = "eu-central-1")] EuCentral1,
        [EnumMember(Value = "us-east-1")] UsEast1,
        [EnumMember(Value = "us-west-1")] UsWest1,
        [EnumMember(Value = "us-west-2")] UsWest2,
        [EnumMember(Value = "us-gov-west-1")] UsGovWest1,
        [EnumMember(Value = "ap-southeast-1")] ApSoutheast1,
        [EnumMember(Value = "ap-southeast-2")] ApSoutheast2,
        [EnumMember(Value = "ap-northeast-1")] ApNortheast1,
        [EnumMember(Value = "sa-east-1")] SaEast1,
        [EnumMember(Value = "ca-north-1")] CaNorth1
    }
}