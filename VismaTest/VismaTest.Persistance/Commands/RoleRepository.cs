using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VismaTest.Domain.Entities;
using VismaTest.Domain.Repositories;

namespace VismaTest.Persistance.Commands
{
    public class RoleRepository : IRolRepository
    {
        private readonly VismaTestDbContext _context;

        public RoleRepository(VismaTestDbContext context)
        {
            _context = context;
        }
        public async Task<Role> InsertAsync(Role user)
        {
            var result = await _context.Roles.AddAsync(user);
            return result.Entity;
        }

        public void Update(Role role)
        {
            _context.Entry(role);
        }

        public void Delete(Role role)
        {
            _context.Remove(role);

        }
        public async Task<Role> GetById(Guid id)
        {
            var role = _context.Roles
                .Where(d => d.Id == id);
            return role.ToList().FirstOrDefault();
        }


        public Role GetByIdSync(Guid id) =>
            _context.Roles.Find(id);

        public void SaveSync() =>
            _context.SaveChanges();

        public List<Role> GetAll()
        {
            var roles = _context.Roles;
            return roles.ToList();
        }
    }
}
