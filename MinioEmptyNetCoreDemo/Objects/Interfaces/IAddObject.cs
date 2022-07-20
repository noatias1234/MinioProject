using Minio;

namespace MinioEmptyNetCoreDemo.Objects.Interfaces
{
    public interface IAddObject
    {
        Task Add(MinioClient minioClient, string objectName, string bucketName, string fileName, string contentType);
    }
}
