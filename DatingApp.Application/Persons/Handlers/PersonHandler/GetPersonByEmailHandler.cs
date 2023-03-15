using DatingApp.Application.Persons.Queries.GetAllPerson;
using DatingApp.Application.Persons.Queries.GetAllPersonsByEmail;
using DatingApp.Domaine.Entities;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Persons.Handlers
{
  public class GetPersonByEmailHandler : IRequestHandler <GetPersonsByEmailQuery, Person>
    {
        
            private readonly IMediator _mediator;

            public GetPersonByEmailHandler(IMediator mediator)
            {
                _mediator = mediator;
            }
            public async Task<Person> Handle(GetPersonsByEmailQuery request, CancellationToken cancellationToken)
            {
                var Persons = await _mediator.Send(new GetAllPersonsQuery());
                var selectedPerson = Persons.FirstOrDefault(x => x.Email.ToLower().Contains(request.Email.ToLower()));
                return selectedPerson;
            }
        }
    
}
