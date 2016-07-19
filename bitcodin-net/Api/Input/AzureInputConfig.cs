#region

using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Input
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class AzureInputConfig
    {
        [JsonProperty(PropertyName = "type")]
        public InputType Type { get; set; }

        [JsonProperty(PropertyName = "accountName")]
        public string AccountName { get; set; }

        [JsonProperty(PropertyName = "accountKey")]
        public string AccountKey { get; set; }


        [JsonProperty(PropertyName = "container")]
        public string Container { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        public AzureInputConfig()
        {
            Type = InputType.Abs;
        }
    }
}