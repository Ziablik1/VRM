using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VRM.DAL.Models;
using VRM.DAL.Data;

namespace VRM.DAL.Repos
{
    public class AccountRepository : IUserRepository
    {
        private readonly VRMContext _context;
        private readonly DbSet<User> _set;

        public AccountRepository(VRMContext context)
        {
            _context = context;
            _set = _context.Set<User>();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _set.ToListAsync();
        }

        public User GetById(string id)
        {
            return _set.Find(id);
        }

        public void Add(User obj)
        {
            _set.Add(obj);
            _context.SaveChanges();
        }

        public void Update(User obj)
        {
            _set.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            User existing = _set.Find(id);
            _set.Remove(existing);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
