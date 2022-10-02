using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WebApiKhanhPhong.DbContext;
using WebApiKhanhPhong.Services;
using WebApiKhanhPhong.Services.IServices;

namespace WebApiKhanhPhong.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection service)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(AppSettings.ConnectionStrings));
            
            return service;
        }
        
        public static IServiceCollection AddService(this IServiceCollection service)
        {
            service.AddScoped<IBookService, BookService>();
            service.AddScoped<IJwtUtils, JwtUtils>();
            return service;
        }
        
        public static IServiceCollection AddAutoMapper(this IServiceCollection service)
        {
            //auto mapper config
            var mapper = MappingConfig.RegisterMaps().CreateMapper();
            service.AddSingleton(mapper);
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return service;
        }
        
        public static IServiceCollection AddSwagger(this IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiKhanhPhong", Version = "v1" });
            });
            return service;
        }
    }
}