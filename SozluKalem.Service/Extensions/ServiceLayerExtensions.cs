using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SozluKalem.Data.Context;
using SozluKalem.Data.Repositories.Absractions;
using SozluKalem.Data.Repositories.Concretes;
using SozluKalem.Data.UnitOfWorks;
using SozluKalem.Service.Extensions.FluentValidations;
using SozluKalem.Service.Helpers.Images;
using SozluKalem.Service.Services.Abstractions;
using SozluKalem.Service.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SozluKalem.Data.Mappings;
using SozluKalem.Service.AutoMapper.Articles;
using SozluKalem.Service.AutoMapper.Users;
using SozluKalem.Service.AutoMapper.Categories;

namespace SozluKalem.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();


            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddAutoMapper(typeof(ArticleProfile).Assembly);
            services.AddAutoMapper(typeof(CategoryProfile).Assembly);
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ArticleProfile>();
                cfg.AddProfile<CategoryProfile>();
                cfg.AddProfile<UserProfile>();
            }, typeof(ArticleProfile).Assembly);


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllersWithViews()
                .AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
                    opt.DisableDataAnnotationsValidation = true;
                    opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
                });



            return services;

        }
    }
    
}
