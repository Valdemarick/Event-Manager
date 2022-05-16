using Application.Common.Interfaces.Contexts;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Common.Mappings;
using Infastructure.Persistence.Contexts;
using Infastructure.Persistence.Repositories;
using Infastructure.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Reflection;

namespace Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                                                                   .AllowAnyMethod()
                                                                   .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => { });

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseNpgsql(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureApplicationDbContext(this IServiceCollection services) =>
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        public static void ConfigureAutoMapper(this IServiceCollection services) =>
            services.AddAutoMapper(Assembly.Load("Application"));

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            //services.AddScoped<IOrganizerRepository, OrganizerRepository>();
            //services.AddScoped<IEventRepository, EventRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IPlaceService, PlaceService>();
            //services.AddScoped<IOrganizerService, OrganizerService>();
            //services.AddScoped<IEventService, EventService>();
        }
    }
}