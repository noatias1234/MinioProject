


var services = new ServiceCollection();
var settings = new Settings
{
    HostName = "localhost"
};
services.AddInfrastructureLayer(settings);
var serviceProvider = services.BuildServiceProvider();

var subscriber = serviceProvider.GetRequiredService<ISubscriber>();


