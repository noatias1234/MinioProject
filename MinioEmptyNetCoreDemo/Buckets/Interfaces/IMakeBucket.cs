using Minio;

namespace MinioEmptyNetCoreDemo.Buckets.Interfaces
{
    public interface IMakeBucket
    {
        Task Make(MinioClient minio, string bucketName);
    }
}
