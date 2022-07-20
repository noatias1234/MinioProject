using Minio;
using MinioEmptyNetCoreDemo.Buckets.Interfaces;
using MinioEmptyNetCoreDemo.Objects.Interfaces;

namespace MinioEmptyNetCoreDemo.Buckets
{
    public class MakeBucket : IMakeBucket
    {
        private static MinioSettings? _minioSettings;
        private readonly IAddObject _addObject;

        public MakeBucket(MinioSettings? minioSettings, IAddObject addObject)
        {
            _minioSettings = minioSettings;
            _addObject = addObject;
        }
        public async Task Make(MinioClient minio, string bucketName)
        {
            try
            {
                await minio.MakeBucketAsync(
                    new MakeBucketArgs()
                        .WithBucket(bucketName)
                        .WithLocation(_minioSettings?.Location)
                );
                Console.WriteLine($"Created bucket {bucketName}");
                await _addObject.Add(minio, "example", "maps", "example", "txt");


            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
            }
        }
    }
}
