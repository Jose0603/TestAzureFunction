using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestAzureFunction.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        // Register your services with Autofac here
        builder.RegisterType<ServiceTest>().As<IServiceTest>().InstancePerLifetimeScope();
    })
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();