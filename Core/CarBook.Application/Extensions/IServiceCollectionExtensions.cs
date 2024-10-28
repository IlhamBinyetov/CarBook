using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
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

            //  Car Services
            services.AddScoped<GetCarByIdQueryHandler>();
            services.AddScoped<GetCarQueryHandler>();
            services.AddScoped<CreateCarCommandHandler>();
            services.AddScoped<UpdateCarCommandHandler>();
            services.AddScoped<RemoveCarCommandHandler>();
            services.AddScoped<GetCarWithBrandQueryHandler>();

            // Category Services
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();

            //Contact Services
            services.AddScoped<GetContactByIdQueryHandler>();
            services.AddScoped<GetContactQueryHandler>();
            services.AddScoped<CreateContactCommandHandler>();
            services.AddScoped<UpdateContactCommandHandler>();
            services.AddScoped<RemoveContactCommandHandler>();

            return services;
        }
    }
}
