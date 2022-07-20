using Minio;
using MinioEmptyNetCoreDemo.Objects.Interfaces;

namespace MinioEmptyNetCoreDemo.Objects
{
    public class RemoveObject : IRemoveObject
    {
        public async Task Remove(MinioClient minioClient, string objectName
            , string bucketName)
        {
            try
            {
                var args = new RemoveObjectArgs()
                    .WithBucket(bucketName)
                    .WithObject(objectName);

                await minioClient.RemoveObjectAsync(args);
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket-Object]  Exception: {e}");
            }
        }
    }
}
