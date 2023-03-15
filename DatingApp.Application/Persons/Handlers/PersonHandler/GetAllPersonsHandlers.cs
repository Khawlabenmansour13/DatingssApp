
using DatingApp.Application.Persons.Queries.GetAllPerson;
using DatingApp.Domaine.Entities;
using DatingApp.Infrastructure.Repositories.PersonRepository.PersonQuery;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Handlers
{
    public class GetAllPersonsHandlers : IRequestHandler<GetAllPersonsQuery, List<Person>>
    {
       
            private readonly IPersonQueryRepository _personQueryRepository;

            public GetAllPersonsHandlers(IPersonQueryRepository _personQueryRepository)
            {
               this._personQueryRepository = _personQueryRepository;
            }
            public async Task<List<Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
            {
                return (List<Person>)await _personQueryRepository.GetAllPersonsAsync();
            }
        
    }
}
