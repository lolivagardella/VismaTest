using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using VismaTest.Domain.Repositories;

namespace VismaTest.Persistance
{
    [ExcludeFromCodeCoverage]
    public class UsersDbContextUnitOfWork : IUnitOfWork
    {
        private readonly VismaTestDbContext _context;

        public UsersDbContextUnitOfWork(VismaTestDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveSync()
        {
            _context.SaveChanges();
        }
    }
}
