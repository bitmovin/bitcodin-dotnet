#region

using System.Collections.Generic;
using com.bitmovin.bitcodin.Api;
using com.bitmovin.bitcodin.Api.Exception;
using com.bitmovin.bitcodin.Api.Input;
using com.bitmovin.bitcodin.Api.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace com.bitmovin.bitcodin.test
{
    [TestClass]
    public class BitCodingNet
    {
        private static BitcodinApi _api;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            // TODO: Specifiy API Code here
            _api = new BitcodinApi("YOU_API_KEY");
        }

        [TestMethod]
        public void CreateInputTest()
        {
            // TODO: Specify an input URL
            var inputConfig = new HttpInputConfig {Url = "Sintel-original-short.mkv"};
            var result = _api.CreateInput(inputConfig);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.MediaConfigurations);
            Assert.AreNotEqual(0, result.MediaConfigurations.Count);
        }

        [TestMethod]
        public void GetInputTest()
        {
            // TODO: Replace 0 with ID from "CreateInputTest"
            var result = _api.GetInput(0);
            Assert.AreEqual("Sintel-original-short.mkv", result.Filename);
        }

        [TestMethod]
        public void ListInputsTest()
        {
            var result = _api.ListInputs(0);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Inputs);
            Assert.AreNotEqual(0, result.Inputs.Count);
            Assert.AreNotEqual(0L, result.TotalCount);
        }

        [TestMethod]
        public void DeleteInputTest()
        {
            // TODO: Replace 0 with ID from "CreateInputTest"
            _api.DeleteInput(0);
        }

        [TestMethod]
        public void ListEncodingProfilesTest()
        {
            var results = _api.ListEncodingProfile(0);
            Assert.IsNotNull(results);
            Assert.AreNotEqual(0L, results.TotalCount);
            Assert.AreNotEqual(0, results.Profiles.Count);
        }

        [TestMethod]
        public void CreateEncodingProfile()
        {
            var profile = new EncodingProfile
            {
                Name = "TestProfile",
                VideoStreamConfigs = new List<VideoStreamConfig>
                {
                    new VideoStreamConfig
                    {
                        Bitrate = 1200000,
                        Codec = VideoCodec.H264,
                        Width = 1280,
                        Height = 720,
                        Rate = 24,
                        Profile = Profile.Main,
                        Preset = Preset.Premium
                    }
                },
                AudioStreamConfigs = new List<AudioStreamConfig>
                {
                    new AudioStreamConfig
                    {
                        DefaultStreamId = 0,
                        Bitrate = 192000
                    }
                }
            };

            var result = _api.CreateEncodingProfile(profile);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetEncodingProfilesTest()
        {
            // TODO: Replace 0 with ID from "CreateEncodingProfile"
            var results = _api.GetEncodingProfile(0);
            Assert.IsNotNull(results);
            Assert.AreEqual(24, results.VideoStreamConfigs[0].Rate);
        }

        [TestMethod]
        public void ListJobsTest()
        {
            var results = _api.ListJobs(0);
            Assert.IsNotNull(results);
            Assert.IsNotNull(results.Jobs);
            Assert.IsTrue(results.TotalCount > 0);
            Assert.IsTrue(results.Jobs.Count > 0);
        }

        [TestMethod]
        public void GetJobTest()
        {
            // TODO: Replace 0 with a Job ID
            var results = _api.GetJobDetails(0);
            Assert.IsNotNull(results);
            Assert.AreEqual(0, results.JobId);
        }

        [TestMethod]
        public void MonthlyStatisticsTest()
        {
            var result = _api.GetMonthlyStatistic();
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0L, result.TotalBytesWritten);
        }

        [TestMethod]
        [ExpectedException(typeof(BitcodinApiException))]
        public void GetInvoiceInformationTest()
        {
            var result = _api.GetInvoiceInformation();
            Assert.IsNotNull(result);
        }
    }
}