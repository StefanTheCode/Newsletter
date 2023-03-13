using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saga.Core.Concrete.Brokers;

namespace Saga.Core.DependencyRegisters
{
    public static class RegisterSagaCore
    {
        public static IServiceCollection AddSagaCore(this IServiceCollection services, IConfiguration configuration)
        {
            var massTransitSettings = new MassTransitSettings();
            configuration.GetSection(nameof(MassTransitSettings)).Bind(massTransitSettings);

            services.Configure<MassTransitSettings>(configuration.GetSection(nameof(MassTransitSettings)));
            services.AddSingleton(massTransitSettings);

            return services;
        }
    }
}