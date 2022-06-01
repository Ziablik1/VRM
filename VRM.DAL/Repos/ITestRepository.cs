using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRM.DAL.Models;

namespace VRM.DAL.Repos
{
    public interface ITestRepository
    {
        IEnumerable<Test> GetAll();

        Test GetById(string id);

        void Add(Test obj);

        void Update(Test obj);

        void Delete(string id);

        void Save();
    }
}
