using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VRM.DAL.Models;

namespace VRM.DAL.Data
{
    public partial class VRMContext : DbContext
    {
        public VRMContext(DbContextOptions<VRMContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<QA> QA { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<TQ> TQ { get; set; }
        public virtual DbSet<TS> TS { get; set; }
    }
}
