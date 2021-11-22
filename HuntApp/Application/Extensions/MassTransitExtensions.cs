using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using Microsoft.Extensions.Configuration;
using UserApi.Consumers;


namespace UserApi.Application.Extensions
{
    public static class MassTransitExtensions
    {
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services)
        {
            services.AddMassTransit
                (configure =>
                {
                    configure.AddConsumer<HuntUserCreatedConsumer>();
                    configure.AddConsumer<HuntUserDeletedConsumer>();
                    configure.AddConsumer<HuntWeaponCreatedConsumer>();
                    configure.AddConsumer<HuntWeaponDeletedConsumer>();


                    configure.UsingRabbitMq((context, cfg) =>
                    {
                        var configuration = context.GetRequiredService<IConfiguration>();
                        string rabbitMqHost = configuration.GetValue<string>("RabbitMq");
                        cfg.Host(rabbitMqHost);

                        cfg.ConfigureEndpoints(context);
                    });
                });

            services.AddMassTransitHostedService();

            return services;
        }
    }
}
