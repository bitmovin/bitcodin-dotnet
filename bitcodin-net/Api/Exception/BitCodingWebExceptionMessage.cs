#region

using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Exception
{
    public class BitcodinWebExceptionMessage
    {
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}