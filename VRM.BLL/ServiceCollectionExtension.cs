using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using VRM.DAL.Models;
using VRM.DAL.Data;
using VRM.DAL.Repos;
using VRM.BLL.Services;

namespace VRM.BLL
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccount, AccountService>();
        }

        public static void AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(DependencyInjection)));
        }
    }
}