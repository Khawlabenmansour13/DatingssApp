using DatingApp.Domaine.Entities;
using DatingApp.Infrastructure.Repositories.CommandRepository.Query;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Repositories.UserRepository.UserQuery
{
    public class UserQueryRepository<T> : QueryRepository<AppUser>, IUserQueryRepository
    { 
        private readonly DataContexte _context;
        public UserQueryRepository(DataContexte context)

        {
            _context = context;

        }
        public async Task<IReadOnlyList<AppUser>> GetAllUsersAsync()
        {
            try
            {
                var dbUser = await _context.Users.ToListAsync().ConfigureAwait(false);


                return dbUser.ToList();

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<AppUser> GetUserByEmail(string email)
        {
            try
            {
                var User = await _context.Users.FindAsync(email).ConfigureAwait(false);

                if (User != null)
                    return User;
                else
                    return null;

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }

        }

   

        public async Task<AppUser> GetUserByIdAsync(Guid id)
        {

            try
            {
                var User = await _context.Users.FindAsync(id).ConfigureAwait(false);

                if (User != null)
                    return User;
                else
                    return null;

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
    }
    
}
