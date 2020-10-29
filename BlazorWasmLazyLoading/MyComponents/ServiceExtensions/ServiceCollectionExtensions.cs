using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyComponents(this IServiceCollection services)
        {
            // some custom registration code here
            return services;
        }
    }
}
