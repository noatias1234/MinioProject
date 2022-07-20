using Minio;
using MinioEmptyNetCoreDemo.Buckets.Interfaces;
using MinioEmptyNetCoreDemo.Objects.Interfaces;

namespace MinioEmptyNetCoreDemo.Buckets
{
    public class BucketExist : IBucketExist
    {
        public MinioSettings? MinioSettings;
        private readonly IMakeBucket _makeBucket;
        private readonly IAddObject _addObject;
        private const string FileLocation = @"C:\Users\barnoaa\source\repos\example.txt";

        public BucketExist(MinioSettings? minioSettings, IMakeBucket makeBucket, IAddObject addObject)
        {
            MinioSettings = minioSettings;
            _makeBucket = makeBucket;
            _addObject = addObject;
        }

        public async Task Check(MinioClient minio, string bucketName)
        {
            try
            {
                var args = new BucketExistsArgs()
                    .WithBucket(bucketName);
                var found = await minio.BucketExistsAsync(args);
                if (!found)
                {
                    await _makeBucket.Make(minio, bucketName);
                }

                
                await _addObject.Add(minio, "example", "maps", FileLocation, "txt");

                Console.WriteLine((found ? "Found" : "Couldn't find ") + "bucket " + bucketName);
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
            }
        }
    }
}