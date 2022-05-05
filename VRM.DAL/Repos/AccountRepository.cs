using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VRM.DAL.Models;
using VRM.DAL.Data;

namespace VRM.DAL.Repos
{
    public class AccountRepository : IUserRepository
    {
        private readonly VRMContext _context;
        private readonly DbSet<User> table;

        public AccountRepository(VRMContext context)
        {
            _context = context;
            table = _context.Set<User>();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await table.ToListAsync();
        }

        public User GetById(string id)
        {
            return table.Find(id);
        }

        public void Add(User obj)
        {
            table.Add(obj);
            _context.SaveChanges();
        }

        public void Update(User obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            User existing = table.Find(id);
            table.Remove(existing);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
