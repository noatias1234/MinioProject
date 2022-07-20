using Minio;

namespace MinioEmptyNetCoreDemo.Objects.Interfaces
{
    public interface IRemoveObject
    { 
        Task Remove(MinioClient minioClient, string objectName, string bucketName);
    }
}
