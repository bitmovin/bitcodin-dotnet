#region

using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using com.bitmovin.bitcodin.Api.Billing;
using com.bitmovin.bitcodin.Api.Exception;
using com.bitmovin.bitcodin.Api.Input;
using com.bitmovin.bitcodin.Api.Job;
using com.bitmovin.bitcodin.Api.Manifest;
using com.bitmovin.bitcodin.Api.Media;
using com.bitmovin.bitcodin.Api.Output;
using com.bitmovin.bitcodin.Api.Statistics;
using com.bitmovin.bitcodin.Api.Thumbnail;
using com.bitmovin.bitcodin.Api.Transfer;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace com.bitmovin.bitcodin.Api
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public class BitcodinApi
    {
        private readonly string _apiUrl;
        private readonly HttpClient _client;

        public string ApiKey { get; }

        public BitcodinApi(string apiKey, bool useHttps = true)
        {
            ApiKey = apiKey;
            _apiUrl = "http" + (useHttps ? "s" : "") + "://portal.bitcodin.com/api/";
            _client = new HttpClient();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            _client.DefaultRequestHeaders.TryAddWithoutValidation("bitcodin-api-version", "v1");
            _client.DefaultRequestHeaders.TryAddWithoutValidation("bitcodin-api-key", ApiKey);
        }

        protected void Post(string url, object jsonObject)
        {
            url = _apiUrl + url;
            var json = JsonConvert.SerializeObject(jsonObject, Formatting.None, new StringEnumConverter());
            var content = new StringContent(json, Encoding.UTF8);
            var response = _client.PostAsync(url, content).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new BitcodinApiException(response);
            }
            response.Content.ReadAsStringAsync().Wait();
        }

        protected T Post<T>(string url, object jsonObject)
        {
            url = _apiUrl + url;
            var json = JsonConvert.SerializeObject(jsonObject, Formatting.None, new StringEnumConverter());
            var content = new StringContent(json, Encoding.UTF8);
            var response = _client.PostAsync(url, content).Result;

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Json: " + json);
                Console.WriteLine("response: " + response);
                throw new BitcodinApiException(response);
            }
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(result);
        }

        protected void Get(string url)
        {
            url = _apiUrl + url;
            var response = _client.GetAsync(url).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new BitcodinApiException(response);
            }
            response.Content.ReadAsStringAsync().Wait();
        }

        protected T Get<T>(string url)
        {
            url = _apiUrl + url;
            var response = _client.GetAsync(url).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new BitcodinApiException(response);
            }
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(result);
        }

        protected void Delete(string url)
        {
            url = _apiUrl + url;
            var response = _client.DeleteAsync(url).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new BitcodinApiException(response);
            }
            response.Content.ReadAsStringAsync().Wait();
        }

        protected T Delete<T>(string url)
        {
            url = _apiUrl + url;
            var response = _client.DeleteAsync(url).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new BitcodinApiException(response);
            }
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(result);
        }

        public Input.Input CreateInput(HttpInputConfig config)
        {
            return Post<Input.Input>("input/create", config);
        }

        public Input.Input CreateInput(AzureInputConfig config)
        {
            return Post<Input.Input>("input/create", config);
        }

        public Input.Input CreateInput(S3InputConfig config)
        {
            return Post<Input.Input>("input/create", config);
        }

        public Input.Input CreateInput(FtpInputConfig config)
        {
            return Post<Input.Input>("input/create", config);
        }

        public Input.Input CreateInput(GcsInputConfig config)
        {
            return Post<Input.Input>("input/create", config);
        }

        public InputList ListInputs(int pageNumber)
        {
            return Get<InputList>("inputs/" + pageNumber);
        }

        public Input.Input GetInput(int id)
        {
            return Get<Input.Input>("input/" + id);
        }

        public void DeleteInput(int id)
        {
            Delete("input/" + id);
        }

        public Output.Output CreateOutput(S3OutputConfig config)
        {
            return Post<Output.Output>("output/create", config);
        }

        public Output.Output CreateOutput(GcsOutputConfig config)
        {
            return Post<Output.Output>("output/create", config);
        }

        public Output.Output CreateOutput(AzureOutputConfig config)
        {
            return Post<Output.Output>("output/create", config);
        }

        public Output.Output CreateOutput(FtpOutputConfig config)
        {
            return Post<Output.Output>("output/create", config);
        }

        public OutputList ListOutputs(int pageNumber)
        {
            return Get<OutputList>("outputs/" + pageNumber);
        }

        public Output.Output GetOutput(int id)
        {
            return Get<Output.Output>($"output/{id}");
        }

        public void DeleteOutput(int id)
        {
            Delete($"output/{id}");
        }

        public EncodingProfile CreateEncodingProfile(EncodingProfileConfig profile)
        {
            return Post<EncodingProfile>("encoding-profile/create", profile);
        }

        public EncodingProfileList ListEncodingProfile(int pageNumber)
        {
            return Get<EncodingProfileList>($"encoding-profiles/{pageNumber}");
        }

        public EncodingProfile GetEncodingProfile(int id)
        {
            return Get<EncodingProfile>($"encoding-profile/{id}");
        }

        public Job.Job CreateJob(JobConfig jobConfig)
        {
            return Post<Job.Job>("job/create", jobConfig);
        }

        public JobList ListJobs(int pageNumber)
        {
            return Get<JobList>($"jobs/{pageNumber}");
        }

        public JobDetails GetJobDetails(int id)
        {
            return Get<JobDetails>($"job/{id}");
        }

        public void Transfer(TransferConfig config)
        {
            Post("job/transfer", config);
        }

        public Transfer.Transfer[] ListTransfers(TransferConfig id)
        {
            return Get<Transfer.Transfer[]>($"job/{id}/transfers");
        }

        public MonthlyStatistic GetMonthlyStatistic()
        {
            return Get<MonthlyStatistic>("statistics");
        }

        public Statistic GetStatistics(string from, string to)
        {
            return Get<Statistic>($"statistics/jobs/{from}/{to}");
        }

        public InvoiceInformation GetInvoiceInformation()
        {
            return Get<InvoiceInformation>("payment/invoiceinfo");
        }

        public void UpdateInvoiceInformation(InvoiceInformation invoiceInformation)
        {
            Post("payment/invoiceinfo", invoiceInformation);
        }

        public VttMpd CreateVtt(VttMpdConfig config)
        {
            return Post<VttMpd>("manifest/mpd/vtt", config);
        }

        public VttHls CreateVtt(VttHls config)
        {
            return Post<VttHls>("manifest/hls/vtt", config);
        }

        public Thumbnail.Thumbnail CreateThumbnail(ThumbnailConfig config)
        {
            return Post<Thumbnail.Thumbnail>("thumbnail", config);
        }

        public Sprite CreateSprite(SpriteConfig config)
        {
            return Post<Sprite>("sprite", config);
        }
    }
}