using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace Ae.Gengo.Client
{
    /// <summary>
    /// Provides extensions to interface with the Microsoft DI container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the Gengo V2 client services to the specified <see cref="IServiceCollection"/>.
        /// Client is registered as <see cref="IGengoClientV2"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <param name="configureClient"></param>
        /// <returns></returns>
        public static IServiceCollection AddGengoClientV2(this IServiceCollection services, IGengoConfigV2 config, Action<HttpClient> configureClient)
        {
            services.AddSingleton(config)
                .AddTransient<GengoHandlerV2>()
                .AddSingleton<IGengoClientV2, GengoClientV2>();

            services.AddHttpClient<IGengoClientV2, GengoClientV2>(configureClient)
                .AddHttpMessageHandler<GengoHandlerV2>();

            return services;
        }
    }
}
