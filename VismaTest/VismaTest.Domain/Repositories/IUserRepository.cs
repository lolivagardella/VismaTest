using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VismaTest.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<Entities.User> InsertAsync(Entities.User user);
        void Update(Entities.User user);
        Task<Entities.User> GetById(Guid id);
        Entities.User GetByEmail(string email);
        List<Entities.User> GetAll();
        Entities.User GetByIdSync(Guid id);
        void Delete(Entities.User user);
        void SaveSync();
    }
}
