using MinioEmptyNetCoreDemo;
using MinioEmptyNetCoreDemo.Buckets;
using MinioEmptyNetCoreDemo.Buckets.Interfaces;
using MinioEmptyNetCoreDemo.Objects;
using MinioEmptyNetCoreDemo.Objects.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration.GetSection(("Settings")).Get<MinioSettings>();

builder.Services.AddSingleton(settings);
builder.Services.AddSingleton<IBucketExist, BucketExist>();
builder.Services.AddSingleton<IMakeBucket, MakeBucket>();
builder.Services.AddSingleton<IAddObject, AddObject>();


builder.Services.AddHostedService<Worker>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.Run();
