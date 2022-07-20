using Minio;

namespace MinioEmptyNetCoreDemo.Buckets.Interfaces;

public interface IBucketExist
{
    public  Task Check(MinioClient minio, string bucketName);

}