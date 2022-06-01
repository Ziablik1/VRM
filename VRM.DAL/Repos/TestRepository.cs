using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRM.DAL.Models;
using VRM.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace VRM.DAL.Repos
{
    public class TestRepository: ITestRepository
    {
        private readonly VRMContext _context;
        private readonly DbSet<Test> _set;

        public TestRepository(VRMContext context)
        {
            _context = context;
            _set = _context.Set<Test>();
        }

        public IEnumerable<Test> GetAll()
        {
            return _set.ToList();
        }

        public Test GetById(string id)
        {
            return _set.Find(id);
        }

        public void Add(Test obj)
        {
            _set.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Test obj)
        {
            _set.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            Test existing = _set.Find(id);
            _set.Remove(existing);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
