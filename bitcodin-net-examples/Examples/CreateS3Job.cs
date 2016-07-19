#region

using System;
using System.Threading;
using com.bitmovin.bitcodin.Api;
using com.bitmovin.bitcodin.Api.Exception;
using com.bitmovin.bitcodin.Api.Input;
using com.bitmovin.bitcodin.Api.Job;
using com.bitmovin.bitcodin.Api.Media;

#endregion

namespace com.bitmovin.bitcodin.examples.Examples
{
    public static class CreateS3Job
    {
        public static void Run()
        {
            /* Create BitcodinApi */
            const string apiKey = "YOUR_API_KEY";
            var bitApi = new BitcodinApi(apiKey);

            /* Create URL Input */
            var s3InputConfig = new S3InputConfig
            {
                AccessKey = "YOUR_ACCESSKEY",
                SecretKey = "YOUR_SECRETKEY",
                Bucket = "Bucket",
                Region = "Region",
                ObjectKey = "path/to/file.mkv"
            };

            Input input;
            try
            {
                input = bitApi.CreateInput(s3InputConfig);

                Console.WriteLine("Created Input: S3 " + input.Filename);
            }
            catch (BitcodinApiException e)
            {
                Console.WriteLine("Could not create S3 input: " + e);
                return;
            }

            /* Create EncodingProfile */
            var videoConfig1 = new VideoStreamConfig
            {
                Bitrate = 4800000,
                Width = 1920,
                Height = 1080,
                Profile = Profile.Main,
                Preset = Preset.Premium
            };

            var videoConfig2 = new VideoStreamConfig
            {
                Bitrate = 2400000,
                Width = 1280,
                Height = 720,
                Profile = Profile.Main,
                Preset = Preset.Premium
            };

            var videoConfig3 = new VideoStreamConfig
            {
                Bitrate = 1200000,
                Width = 854,
                Height = 480,
                Profile = Profile.Main,
                Preset = Preset.Premium
            };

            var encodingProfileConfig = new EncodingProfileConfig {Name = "S3TestProfile"};

            encodingProfileConfig.VideoStreamConfigs.Add(videoConfig1);
            encodingProfileConfig.VideoStreamConfigs.Add(videoConfig2);
            encodingProfileConfig.VideoStreamConfigs.Add(videoConfig3);

            var audioStreamConfig = new AudioStreamConfig
            {
                DefaultStreamId = 0,
                Bitrate = 192000
            };
            encodingProfileConfig.AudioStreamConfigs.Add(audioStreamConfig);

            EncodingProfile encodingProfile;
            try
            {
                encodingProfile = bitApi.CreateEncodingProfile(encodingProfileConfig);
                Console.WriteLine("Could  create profile: " + encodingProfile.Name);
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
        }
    }
}