#region

using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

#endregion

namespace com.bitmovin.bitcodin.Api.Output
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class AzureOutputConfig
    {
        [JsonProperty(PropertyName = "type")]
        public OutputType Type { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "accountName")]
        public string AccountName { get; set; }

        [JsonProperty(PropertyName = "accountKey")]
        public string AccountKey { get; set; }

        [JsonProperty(PropertyName = "container")]
        public string Container { get; set; }

        [JsonProperty(PropertyName = "prefix")]
        public string Prefix { get; set; }

        [JsonProperty(PropertyName = "createSubDirectory")]
        public bool CreateSubDirectory { get; set; }

        public AzureOutputConfig()
        {
            Type = OutputType.Azure;
        }
    }
}