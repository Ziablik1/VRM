using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using VRM.DAL.Models;

namespace VRM.DAL.Repos
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();

        User GetById(string id);

        void Add(User obj);

        void Update(User obj);

        void Delete(string id);

        void Save();
    }
}
