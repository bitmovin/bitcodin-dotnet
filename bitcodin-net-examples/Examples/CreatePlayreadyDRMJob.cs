#region

using System;
using System.Threading;
using com.bitmovin.bitcodin.Api;
using com.bitmovin.bitcodin.Api.Exception;
using com.bitmovin.bitcodin.Api.Input;
using com.bitmovin.bitcodin.Api.Job;
using com.bitmovin.bitcodin.Api.Media;
using com.bitmovin.bitcodin.Api.Output;
using com.bitmovin.bitcodin.Api.Transfer;

#endregion

namespace com.bitmovin.bitcodin.examples.Examples
{
    public static class CreatePlayreadyDrmJob
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
            }
            catch (BitcodinApiException e)
            {
                Console.WriteLine("Could not create encoding profile: " + e);
                return;
            }

            /* CREATE DRM PLAYREADY CONFIG */
            var playreadyDrmConfig = new PlayReadyDrmConfig
            {
                Key = "",
                KeySeed = "XVBovsmzhP9gRIZxWfFta3VVRPzVEWmJsazEJ46I",
                Kid = "746573745f69645f4639465043304e4f",
                LaUrl = "http://playready.directtaps.net/pr/svc/rightsmanager.asmx",
                Method = DrmMethod.MpegCenc
            };

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
            jobConfig.DrmConfig = playreadyDrmConfig;

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

            var outputConfig = new FtpOutputConfig
            {
                Name = "TestFtpOutput",
                Host = "ftp.yourdomain.com/content",
                Username = "Username",
                Password = "pwd"
            };

            Output output;
            try
            {
                output = bitApi.CreateOutput(outputConfig);
                Console.WriteLine("Output has been created: " + output.Name);
            }
            catch (BitcodinApiException e)
            {
                Console.WriteLine("Could not create Output: " + e);
                return;
            }

            var transferConfig = new TransferConfig
            {
                JobId = job.JobId,
                OutputId = output.OutputId
            };

            try
            {
                bitApi.Transfer(transferConfig);
                Console.WriteLine("Output has been transfered");
            }
            catch (BitcodinApiException e)
            {
                Console.WriteLine("Could not transfer Output: " + e);
            }
        }
    }
}