using Minio;

namespace MinioProject.Buckets
{
    public class BucketExist
    {
        private static MinioSettings _minioSettings = null!;

        public BucketExist(MinioSettings minioSettings)
        {
            _minioSettings = minioSettings;
        }

        public static async Task BucketExistCheck(MinioClient minio, string bucketName)
        {
            try
            {
                Console.WriteLine("Running example for API: BucketExistsAsync");
                var args = new BucketExistsArgs()
                    .WithBucket(bucketName);
                var found = await minio.BucketExistsAsync(args);
                if (found)
                {
                    await MakeBucket.CreateBucket(minio, bucketName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
            }
        }
    }
}