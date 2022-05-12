using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VRM.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VRM.DAL.Data
{
    public partial class VRMContext : IdentityDbContext<User, AppRole, string>
    {
        public VRMContext(DbContextOptions<VRMContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<TQ> tqs { get; set; }
        public DbSet<TS> tss { get; set; }
        public DbSet<QA> qas { get; set; }
    }
}
