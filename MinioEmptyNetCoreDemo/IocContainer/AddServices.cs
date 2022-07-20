using MinioEmptyNetCoreDemo.Buckets;
using MinioEmptyNetCoreDemo.Buckets.Interfaces;
using MinioEmptyNetCoreDemo.Objects;
using MinioEmptyNetCoreDemo.Objects.Interfaces;

namespace MinioEmptyNetCoreDemo.IocContainer
{
    public static class AddServices
    {
        public static void AddMinioServices(this IServiceCollection services, MinioSettings minioSettings)
        {
            services.AddSingleton(minioSettings);
            services.AddSingleton<IBucketExist, BucketExist>();
            services.AddScoped<IMakeBucket,MakeBucket>();
            services.AddScoped<IRemoveObject, RemoveObject>();
            services.AddScoped<IAddObject, AddObject>();
        }
    }
}
