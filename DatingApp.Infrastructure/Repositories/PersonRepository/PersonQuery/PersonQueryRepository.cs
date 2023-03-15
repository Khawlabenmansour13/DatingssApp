using DatingApp.Domaine.Entities;
using DatingApp.Infrastructure.Repositories.CommandRepository.Query;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Repositories.PersonRepository.PersonQuery
{
    public class PersonQueryRepository<T> : QueryRepository<Person>, IPersonQueryRepository
    { 
        private readonly DataContexte _context;
        public PersonQueryRepository(DataContexte context)

        {
            _context = context;

        }
        public async Task<IReadOnlyList<Person>> GetAllPersonsAsync()
        {
            try
            {
                var dbUser = await _context.Persons.ToListAsync().ConfigureAwait(false);


                return dbUser.ToList();

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Person> GetPersonByEmail(string email)
        {
            try
            {
                var User = await _context.Persons.FindAsync(email).ConfigureAwait(false);

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

   

        public async Task<Person> GetPersonByIdAsync(Guid id)
        {

            try
            {
                var User = await _context.Persons.FindAsync(id).ConfigureAwait(false);

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
