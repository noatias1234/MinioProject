using Minio;
using Minio.DataModel;

namespace MinioProject.Buckets
{
    internal class MakeBucket
    {
        private static MinioSettings? _minioSettings;

        public MakeBucket(MinioSettings? minioSettings)
        {
            _minioSettings = minioSettings;
        }
        public static async Task CreateBucket(MinioClient minio, string bucketName)
        {
            try
            {
                await minio.MakeBucketAsync(
                    new MakeBucketArgs()
                        .WithBucket(bucketName)
                        .WithLocation(_minioSettings?.Location)
                );
                Console.WriteLine($"Created bucket {bucketName}");

            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
            }
        }
    }
}
