using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VRM.DAL
{
    public static class DependencyInjection
    {
        public static void AddVRMDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContext(configuration);
            services.AddRepositories();
        }
    }
}