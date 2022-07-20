using Minio;
using MinioEmptyNetCoreDemo.Objects.Interfaces;

namespace MinioEmptyNetCoreDemo.Objects
{
    public class AddObject : IAddObject
    {
        public async Task Add(MinioClient minioClient, string objectName,
            string bucketName, string fileName, string contentType)
        {
            try
            {
                var bs = await File.ReadAllBytesAsync(fileName);
                using (var fileStream = new MemoryStream(bs))
                {
                    var args = new PutObjectArgs()
                        .WithBucket(bucketName)
                        .WithObject(objectName)
                        .WithStreamData(fileStream)
                        .WithObjectSize(fileStream.Length)
                        .WithContentType("application/octet-stream");
                    await minioClient.PutObjectAsync(args);
                }

                Console.WriteLine($"Uploaded object {objectName} to bucket {bucketName}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
            }
        }
    }
}
