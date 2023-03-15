

using DatingApp.Application.Persons.Queries.GetAllPerson;
using DatingApp.Application.Persons.Queries.GetPersonByIdQuery;
using DatingApp.Domaine.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, Person>
    {
        private readonly IMediator _mediator;

        public GetPersonByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var Persons = await _mediator.Send(new GetAllPersonsQuery());
            var selectedPerson = Persons.FirstOrDefault(x => x.Id == request.Id);
            return selectedPerson;
        }
    }
}
