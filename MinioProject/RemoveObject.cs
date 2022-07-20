using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minio;

namespace MinioProject
{
    internal class RemoveObject
    {
        public static async Task Run(MinioClient minio,
            string bucketName, string MapName)
        {
            var args = new RemoveObjectArgs()
                .WithBucket(bucketName)
                .WithObject(MapName);
            await minio.RemoveObjectAsync(args);
        }
    }
}
