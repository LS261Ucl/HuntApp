using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TraningSessionApi.Consumers;

namespace TraningSessionApi.Application.Extensions
{
    public static class MassTrainsitExtension
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
                    configure.AddConsumer<HuntSessionCreatedConsumer>();
                    configure.AddConsumer<HuntSessionDeletedConsumer>();



                    configure.UsingRabbitMq((context, cfg) =>
                    {
                        //var configuration = context.GetRequiredService<IConfiguration>();
                        //string rabbitMqHost = configuration.GetValue<string>("RabbitMq");
                        //cfg.Host(rabbitMqHost);

                        //cfg.ConfigureEndpoints(context);

                        cfg.Host("amqp://guest:guest@localhost:15672");
                        cfg.ConfigureEndpoints(context);
                    });
                });

            services.AddMassTransitHostedService();

            return services;
        }
    }
}
