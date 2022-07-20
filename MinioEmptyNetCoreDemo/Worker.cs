using Minio;
using MinioEmptyNetCoreDemo.Buckets.Interfaces;

namespace MinioEmptyNetCoreDemo
{
    public class Worker : BackgroundService
    {
        private readonly MinioSettings _minioSettings;
        private readonly IBucketExist _bucketExist;
        private readonly MinioClient _minioClient;

        public Worker(MinioSettings minioSettings, IBucketExist bucketExist)
        {
            _minioSettings = minioSettings;
            _bucketExist = bucketExist;
            _minioClient = new MinioClient().WithEndpoint(minioSettings.EndPoint)
                .WithCredentials(minioSettings.AccessKey,
                    minioSettings.SecretKey)
                .Build();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           await _bucketExist.Check(_minioClient, "maps");
        }
    }
}
