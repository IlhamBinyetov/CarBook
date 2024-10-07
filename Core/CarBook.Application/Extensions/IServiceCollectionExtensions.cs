using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarBook.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            
            //About Services
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<GetAboutQueryHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();
            services.AddScoped<CreateAboutCommandHandler>();



            //Banner Services
            services.AddScoped<GetBannerByIdQueryHandler>();
            services.AddScoped<GetBannerQueryHandler>();
            services.AddScoped<RemoveBannerCommandHandler>();
            services.AddScoped<UpdateBannerCommandHandler>();
            services.AddScoped<CreateBannerCommandHandler>();

            // Brand Services
            services.AddScoped<GetBrandByIdQueryHandler>();
            services.AddScoped<GetBrandQueryHandler>();
            services.AddScoped<CreateBrandCommandHandler>();
            services.AddScoped<UpdateBrandCommandHandler>();
            services.AddScoped<RemoveBrandCommandHandler>();

            return services;
        }
    }
}
