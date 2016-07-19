#region

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

#endregion

namespace com.bitmovin.bitcodin.Api.Job
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum JobStatus
    {
        [EnumMember(Value = "Created")] CREATED,
        [EnumMember(Value = "Enqueued")] ENQUEUED,
        [EnumMember(Value = "In Progress")] INPROGRESS,
        [EnumMember(Value = "Finished")] FINISHED,
        [EnumMember(Value = "Error")] ERROR
    }
}