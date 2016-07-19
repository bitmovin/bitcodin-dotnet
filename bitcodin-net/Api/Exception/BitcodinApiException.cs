#region

using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Exception
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class BitcodinApiException : System.Exception
    {
        private readonly string _content;

        public BitcodinApiException(HttpResponseMessage response)
        {
            _content = response.Content.ReadAsStringAsync().Result;
        }

        public BitcodinWebExceptionMessage ExceptionMessage
            => JsonConvert.DeserializeObject<BitcodinWebExceptionMessage>(_content);
    }
}