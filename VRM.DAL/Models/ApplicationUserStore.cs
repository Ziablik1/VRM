using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using VRM.DAL.Data;

namespace VRM.DAL.Models
{
    public class ApplicationUserStore : UserStore<Student>
    {
        public ApplicationUserStore(VRMContext context) : base(context)
        {
        }
    }
}