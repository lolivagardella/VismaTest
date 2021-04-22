using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VismaTest.Domain.Repositories
{
    public interface IRolRepository
    {
        Task<Entities.Role> InsertAsync(Entities.Role role);
        void Update(Entities.Role role);
        Task<Entities.Role> GetById(Guid id);
        List<Entities.Role> GetAll();
        Entities.Role GetByIdSync(Guid id);
        void Delete(Entities.Role role);
        void SaveSync();
    }
}
