using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRM.DAL.Data;
using Microsoft.Extensions.Configuration;
using VRM.DAL.Models;
using VRM.DAL.Repos;
using Microsoft.EntityFrameworkCore;

namespace VRM.BLL.Services
{
    public class SignUpper
    {
        public void AddNewUser(string username, string email, string password)
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder(); 
            optionsBuilder.UseSqlServer(@"Server = (localdb)\\mssqllocaldb; Database = VRMDB; Trusted_Connection = True; MultipleActiveResultSets = true");
            var context = new VRMContext((DbContextOptions<VRMContext>)optionsBuilder.Options);
            var repo = new EFGenericRepository<Student>(context);
            Student s = new Student { Username = username, Email = email, Password = password};
            repo.Create(s);
        }
    }
}
