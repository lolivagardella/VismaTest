using System.Threading.Tasks;

namespace VismaTest.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        void SaveSync();
    }
}
