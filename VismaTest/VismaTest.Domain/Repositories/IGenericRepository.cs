using System.Collections.Generic;
using System.Threading.Tasks;

namespace VismaTest.Domain.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<T> GetById(string code);
        List<T> GetAll();
        void AddAll(List<T> elementos);
        void ClearAll();
    }

}
