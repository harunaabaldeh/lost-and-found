namespace API.Common.Extensions;

public static class EndpointServiceExtension
{
    public static void MapEndpoints(this WebApplication builder)
    {
        var scope = builder.Services.CreateScope();

        var endpoints = scope.ServiceProvider.GetServices<IEndpoint>();

        foreach (var endpoint in endpoints)
        {
            endpoint.AddRoute(builder);
        }
    }


    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        var endpoints = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(t => t.GetInterfaces().Contains(typeof(IEndpoint)))
            .Where(t => !t.IsInterface);

        foreach (var endpoint in endpoints)
        {
            services.AddScoped(typeof(IEndpoint), endpoint);
        }

        return services;
    }
}