using DatingApp.Domaine.Entities;
using DatingApp.Infrastructure.Repositories.CommandRepository.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Repositories.UserRepository.UserQuery
{
    public interface IUserQueryRepository : IQueryRepository<AppUser>
    {
        //Custom operation which is not generic
        Task<IReadOnlyList<AppUser>> GetAllUsersAsync();
        Task<AppUser> GetUserByIdAsync(Guid id);
        Task<AppUser> GetUserByEmail(string email);
    }
}
