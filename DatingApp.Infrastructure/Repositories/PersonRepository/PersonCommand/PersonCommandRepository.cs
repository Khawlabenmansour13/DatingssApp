using DatingApp.Domaine.Entities;
using DatingApp.Infrastructure.Repositories.CommandRepository.Command;
using Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Repositories.PersonRepository.PersonCommand
{
    public class PersonCommandRepository : CommandRepository<Person>, IPersonCommandRepository
    {
        public PersonCommandRepository(DataContexte context) : base(context)
        {
        }
    }
}

