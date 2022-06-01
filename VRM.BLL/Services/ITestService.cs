using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRM.DAL.Repos;
using VRM.DAL.Models;
using VRM.DAL.Data;

namespace VRM.BLL.Services
{
    public interface ITestService
    {
        IEnumerable<Test> GetAll();

        Test GetById(string id);
        //public IEnumerable<Test> GetTestsByStudentId(int id);
        void Add(Test obj);

        void Update(Test obj);

        void Delete(string id);

        void Save();
    }
}
