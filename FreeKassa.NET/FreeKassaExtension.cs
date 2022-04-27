using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FreeKassa.NET
{
    public static class FreeKassaExtension
    {
        public static IServiceCollection AddFreeKassa(this IServiceCollection services)
        {
            services.AddTransient<IFreeKassaService, FreeKassaService>();

            return services;
        }

        public static IServiceCollection AddFreeKassa(this IServiceCollection services, int merchantId,
            string secret1, string secret2)
        {
            services.AddTransient<IFreeKassaService>(x =>
                new FreeKassaService(new FreeKassaOptions { MerchantId = merchantId, Secret1 = secret1, Secret2 = secret2}));

            return services;
        }

        public static void AddFreeKassa(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FreeKassaOptions>(configuration);
        }

        public static void AddFreeKassa(this IServiceCollection services, Action<FreeKassaOptions> options)
        {
            services.Configure(options);
        }
    }
}
