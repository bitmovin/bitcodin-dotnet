using System;
using com.bitmovin.bitcodin.examples.Examples;

namespace com.bitmovin.bitcodin.examples
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //WORKS    
            CreateJob.Run();
            //CreateS3Job.Run();  
            //CreateSprite.Run(); 
            //CreateFTPJob.Run();
            //CreateHevcJob.Run(); 
            //CreateAsperaJob.Run();
            //CreateVttMpdked.Run();
            //CreateThumbnail.Run(); 
            //CreateWidevineDRMJob.Run();
            //CreatePlayreadyDRMJob.Run(); 
            //CreateCroppedVideoJob.Run(); 
            //CreateRotationVideoJob.Run(); 
            //CreateDeinterlacingJob.Run();
            //CreateWatermarkedVideoJob.Run();
            //CreateMultiAudioStreamJob.Run();
            //CreateChangedFrameSampleRateJob.Run();
            //CreateVideoJobWithDifferentSegmentLength.Run();

            //BAD REQUEST
            //CreateAzureJob.Run(); //Create Inpute //might be because the file doesn't exit anymore

            //ERRORS
            //CreateJobWithStartTime.Run(); //Error during transcoding // jobConfig.StartTime = 90;
            //CreateGCSJob.Run(); //Error during transcoding // jobConfig.StartTime = 90;

            Console.ReadLine();
        }
    }
}