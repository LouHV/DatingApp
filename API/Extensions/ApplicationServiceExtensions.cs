using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;

using API.helpers;
using API.Helpers;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
         public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration config){
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
             services.AddScoped<ITokenService, TokenService>();
             services.AddScoped<IUserRepository,UserRepository>();
             services.AddScoped<LogUserActivity>();
             services.AddScoped<ILikesRepository,LikesRepository>();
             services.AddScoped<IPhotoService,PhotoService>();
             services.AddScoped<IMessageRepository,MessageRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options=>{
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            return services;
         }   
    }
}