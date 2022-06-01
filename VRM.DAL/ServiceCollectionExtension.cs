using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VRM.DAL.Data;
using VRM.DAL.Repos;
using VRM.DAL.Models;

namespace VRM.DAL
{
    public static class ServiceCollectionExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(EFGenericRepository<>));
            services.AddScoped(typeof(IUserRepository), typeof(AccountRepository));
            services.AddScoped(typeof(ITestRepository), typeof(TestRepository));
        }

        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<VRMContext>(options => options.UseSqlServer(connection));
        }
    }
}