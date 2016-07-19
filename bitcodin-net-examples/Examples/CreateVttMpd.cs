#region

using System;
using System.Threading;
using com.bitmovin.bitcodin.Api;
using com.bitmovin.bitcodin.Api.Exception;
using com.bitmovin.bitcodin.Api.Input;
using com.bitmovin.bitcodin.Api.Job;
using com.bitmovin.bitcodin.Api.Manifest;
using com.bitmovin.bitcodin.Api.Media;

#endregion

namespace com.bitmovin.bitcodin.examples.Examples
{
    public static class CreateVttMpdked
    {
        public static void Run()
        {
            /* Create BitcodinApi */
            const string apiKey = "YOUR_API_KEY";
            var bitApi = new BitcodinApi(apiKey);

            var inputConfig = new HttpInputConfig
            {
                Url = "http://bitbucketireland.s3.amazonaws.com/Sintel-two-audio-streams-short.mkv"
            };

            Input input;
            try
            {
                input = bitApi.CreateInput(inputConfig);
                Console.WriteLine("Could create input: " + input.Filename);
            }
            catch (BitcodinApiException e)
            {
                Console.WriteLine("Could not create input: " + e);
                return;
            }


            var encodingProfileConfig = new EncodingProfileConfig {Name = "MyApiTestEncodingProfile"};

            /* CREATE VIDEO STREAM CONFIGS */
            var videoStreamConfig1 = new VideoStreamConfig
            {
                Bitrate = 4800000,
                Height = 1080,
                Width = 1920
            };
            encodingProfileConfig.VideoStreamConfigs.Add(videoStreamConfig1);
            var videoStreamConfig2 = new VideoStreamConfig
            {
                Bitrate = 2400000,
                Height = 720,
                Width = 1280
            };
            encodingProfileConfig.VideoStreamConfigs.Add(videoStreamConfig2);
            var videoStreamConfig3 = new VideoStreamConfig
            {
                Bitrate = 1200000,
                Height = 480,
                Width = 854
            };
            encodingProfileConfig.VideoStreamConfigs.Add(videoStreamConfig3);

            /* CREATE AUDIO STREAM CONFIGS */
            var audioStreamConfig = new AudioStreamConfig {Bitrate = 128000};
            encodingProfileConfig.AudioStreamConfigs.Add(audioStreamConfig);

            /* CREATE ENCODING PROFILE */
            EncodingProfile encodingProfile;
            try
            {
                encodingProfile = bitApi.CreateEncodingProfile(encodingProfileConfig);
                Console.WriteLine("Could create encoding profile: " + encodingProfile.Name);
            }
            catch (BitcodinApiException e)
            {
                Console.WriteLine("Could not create encoding profile: " + e);
                return;
            }

            /* Create Job */
            Console.WriteLine("Create Job");
            var jobConfig = new JobConfig
            {
                EncodingProfileId = encodingProfile.EncodingProfileId,
                InputId = input.InputId
            };
            jobConfig.ManifestTypes.Add(ManifestType.MpegDashMpd);
            jobConfig.ManifestTypes.Add(ManifestType.HlsM3U8);
            jobConfig.Speed = Speed.Standard;

            Job job;
            try
            {
                job = bitApi.CreateJob(jobConfig);
            }
            catch (BitcodinApiException e)
            {
                Console.WriteLine("Could not create job: " + e);
                return;
            }

            JobDetails jobDetails;

            do
            {
                try
                {
                    jobDetails = bitApi.GetJobDetails(job.JobId);
                    Console.WriteLine("Status: " + jobDetails.JobStatus +
                                      " - Enqueued Duration: " + jobDetails.EnqueueDuration + "s" +
                                      " - Realtime Factor: " + jobDetails.RealtimeFactor +
                                      " - Encoded Duration: " + jobDetails.EncodedDuration + "s" +
                                      " - Output: " + jobDetails.BytesWritten/(double) 1024/1024 + "MB" +
                                      " - Duration: " + jobDetails.Duration +
                                      " - FrameRate: " + jobDetails.FrameRate +
                                      " - JobId: " + jobDetails.JobId +
                                      " - SegmentsSplitted: " + jobDetails.SegmentsSplitted);
                }
                catch (BitcodinApiException)
                {
                    Console.WriteLine("Could not get any job details");
                    return;
                }


                if (jobDetails.JobStatus.ToUpper().Equals(Enum.GetName(typeof(JobStatus), 4)))
                {
                    Console.WriteLine("Error during transcoding");
                    return;
                }

                Thread.Sleep(2000);
            } while (!jobDetails.JobStatus.ToUpper().Equals(Enum.GetName(typeof(JobStatus), 3)));

            Console.WriteLine("Job with ID " + job.JobId + " finished successfully!");

            /* CREATE MPD WITH YOUR VTT SUBTITLES */
            Console.WriteLine("Create SUBTITLES");
            var engSub = new VttSubtitle
            {
                LangLong = "English",
                LangShort = "eng",
                Url = "https://www.iandevlin.com/html5test/webvtt/upc-video-subtitles-en.vtt"
            };

            var deSub = new VttSubtitle
            {
                LangLong = "German",
                LangShort = "de",
                Url = "http://url.to/your/eng.vtt"
            };

            var subtitles = new VttSubtitle[2];
            subtitles[0] = engSub;
            subtitles[1] = deSub;

            var vttMpdConfig = new VttMpdConfig
            {
                OutputFileName = "test",
                JobId = job.JobId,
                Subtitles = subtitles
            };

            try
            {
                var vtt = bitApi.CreateVtt(vttMpdConfig);
                Console.WriteLine("Could create vtt: " + vtt.MpdUrl);
            }
            catch (BitcodinApiException e)
            {
                Console.WriteLine("Could not create vtt: " + e);
            }
        }
    }
}