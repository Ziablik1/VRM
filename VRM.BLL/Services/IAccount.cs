using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRM.DAL.Models;

namespace VRM.BLL.Services
{
    public interface IAccount
    {
        Task<IEnumerable<User>> GetAll();

        User GetById(string id);

        void Add(User obj);

        void Update(User obj);

        void Delete(string id);

        void Save();
    }
}
