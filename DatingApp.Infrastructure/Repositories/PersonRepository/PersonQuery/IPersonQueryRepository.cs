using DatingApp.Domaine.Entities;
using DatingApp.Infrastructure.Repositories.CommandRepository.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Repositories.PersonRepository.PersonQuery
{
    public interface IPersonQueryRepository : IQueryRepository<Person>
    {
        //Custom operation which is not generic
        Task<IReadOnlyList<Person>> GetAllPersonsAsync();
        Task<Person> GetPersonByIdAsync(Guid id);
        Task<Person> GetPersonByEmail(string email);
    }
}
