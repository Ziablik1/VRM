using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VRM.DAL.Data;
using VRM.DAL.Models;
using VRM.DAL.Repos;

namespace VRM.BLL.Services
{
    public static class Service1
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(EFGenericRepository<>));
        }

        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<VRMContext>(options => options.UseSqlServer(connection));
        }
    }
}
