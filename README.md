# [![bitmovin](https://cloudfront-prod.bitmovin.com/wp-content/themes/Bitmovin-V-0.1/images/logo3.png)](http://www.bitmovin.com)
<!-- [![build status](https://travis-ci.org/bitmovin/bitcodin-csharp.svg)](https://travis-ci.org/bitmovin/bitcodin-csharp) 
[![Coverage Status](https://coveralls.io/repos/bitmovin/bitcodin-csharp/badge.svg?branch=master)](https://coveralls.io/r/bitmovin/bitcodin-csharp?branch=master) -->

The bitcodin API for C# is a seamless integration with the [bitmovin cloud transcoding service](http://www.bitmovin.com). It enables the generation of MPEG-DASH and HLS content in just some minutes.

#Preparations

Before you can use the bitcodin-c# API wrapper, you need a version of .NET that is compatible with that platform:

###Windows

* The [.NET framework](https://www.microsoft.com/en-us/download/details.aspx?id=49981). 

###Linux

* The [Mono framework](http://www.mono-project.com/download/#download-lin) runs on Linux. 
* [.NET Core] (https://www.microsoft.com/net/download#core) is being ported to linux.

###OS X
* The [Mono framework](http://www.mono-project.com/download/#download-mac) runs also on OS X. 

#Usage


Before you can start using the api you need to **set your API key.**

Your API key can be found in the **settings of your bitmovin user account**, as shown in the figure below.

![APIKey](https://cloudfront-prod.bitmovin.com/wp-content/uploads/2016/04/api-key.png)

An example how you can instantiate the bitcodin API is shown in the following:

```C#

using com.bitmovin.bitcodin.Api;
public static class BitcodinApiTest
{
  public static void Run()
  {
    const string apiKey = "YOUR_API_KEY";
    var bitApi = new BitcodinApi(apiKey);
  }
}

```

# Example
The following example demonstrates how to create a simple transcoding job, generating MPEG-DASH and Apple HLS out of a single MP4.


```C#

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
        AccessKey = "ACCESSKEY",
        SecretKey = "SECRETKEY",
        Bucket = "BUCKET",
        Region = "REGION",
        ObjectKey = "path/to/file.ext"
      };

      Input input;
      try
      {
        input = bitApi.CreateInput(s3InputConfig);
      }
      catch (BitcodinApiException e)
      {
        Console.WriteLine("Could not create input: " + e);
        return;
      }

      Console.WriteLine("Created Input: " + input.Filename);

      /* Create EncodingProfile */
      var videoConfig1 = new VideoStreamConfig
      {
        Bitrate = 4800000,
        Width = 1920,
        Height = 1080,
        Profile = Profile.MAIN,
        Preset = Preset.PREMIUM
      };

      var videoConfig2 = new VideoStreamConfig
      {
        Bitrate = 2400000,
        Width = 1280,
        Height = 720,
        Profile = Profile.MAIN,
        Preset = Preset.PREMIUM
      };

      var videoConfig3 = new VideoStreamConfig
      {
        Bitrate = 1200000,
        Width = 854,
        Height = 480,
        Profile = Profile.MAIN,
        Preset = Preset.PREMIUM
      };

      var encodingProfileConfig = new EncodingProfileConfig { Name = "DotNetTestProfile" };

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
      }
      catch (BitcodinApiException e)
      {
        Console.WriteLine("Could not create encoding profile: " + e);
        return;
      }

      /* Create Job */
      var jobConfig = new JobConfig
      {
        EncodingProfileId = encodingProfile.EncodingProfileId,
        InputId = input.InputId
      };
      jobConfig.ManifestTypes.Add(ManifestType.MPEG_DASH_MPD);
      jobConfig.ManifestTypes.Add(ManifestType.HLS_M3U8);

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
                            " - Output: " + jobDetails.BytesWritten / (double)1024 / 1024 + "MB");
        }
        catch (BitcodinApiException)
        {
          Console.WriteLine("Could not get any job details");
          return;
        }

        if (jobDetails.JobStatus == JobStatus.ERROR)
        {
          Console.WriteLine("Error during transcoding");
          return;
        }

        Thread.Sleep(2000);
      } while (jobDetails.JobStatus != JobStatus.FINISHED);

      Console.WriteLine("Job with ID " + job.JobId + " finished successfully!");
    }
  }

```

#NuGet
NuGet is a extension for Visual Studio which allows you to search for, install, uninstall and update external packages in your projects and solutions.

NuGet comes installed with the more recent versions of Visual Studio, but you can download it from [here] (https://docs.nuget.org/consume/installing-nuget) if you don’t already have it.

##Install bitcodin-csharp via Package Manager Console
To install bitcodin-csharp, run the following command in the Package Manager Console:
```
    Install-Package bitcodin-csharp -Version 1.0.0
```   

##Managing NuGet Packages Using the Dialog
Detailed information on how to find, install, remove, and update NuGet packages using the Manage NuGet Packages dialog box can be found at [docs.nuget.org](https://docs.nuget.org/consume/package-manager-dialog) 


                                    
