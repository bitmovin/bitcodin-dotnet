#region

using System.Runtime.Serialization;

#endregion

namespace com.bitmovin.bitcodin.Api.Job
{
    public enum DrmMethod
    {
        [EnumMember(Value = "mpeg_cenc")] MpegCenc
    }
}