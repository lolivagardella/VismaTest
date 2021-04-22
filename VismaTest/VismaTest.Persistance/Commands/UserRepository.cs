using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using VismaTest.Domain.Entities;
using VismaTest.Domain.Helpers;
using VismaTest.Domain.Repositories;

namespace VismaTest.Persistance.Commands
{
    [ExcludeFromCodeCoverage]
    public class UserRepository : IUserRepository
    {
        private readonly VismaTestDbContext _context;

        public UserRepository(VismaTestDbContext context)
        {
            _context = context;
        }

        public async Task<User> InsertAsync(User user)
        {
            var result = await _context.Users.AddAsync(user);
            return result.Entity;
        }

        public void Update(User user)
        {
            _context.Entry(user);
        }

        public void Delete(User user)
        {
            _context.Remove(user);

        }
        public async Task<User> GetById(Guid id)
        {
            var user = _context.Users
                .Where(d => d.Id == id);
            return user.ToList().FirstOrDefault();
        }


        public User GetByIdSync(Guid id) =>
            _context.Users.Find(id);

        public void SaveSync() =>
            _context.SaveChanges();

        public List<User> GetAll()
        {
            var users = _context.Users;
            return users.ToList();
        }

        public PagedResult<User> GetAllPaginate(int pagesize, int pageNumber)
        {
            var users = _context.Users
                .GetPaged(pageNumber, pagesize);
            return users;
        }

        public User GetByEmail(string email)
        {
            var user = _context.Users
                .Where(d => d.Email == email);
            return user.ToList().FirstOrDefault();
        }
    }
}
