using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace VRM.BLL
{
    public static class DependencyInjection
    {
        public static void AddVRMBLL(this IServiceCollection services)
        {
            services.AddServices();
            services.AddMapping();
        }
    }
}