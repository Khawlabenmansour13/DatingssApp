using DatingApp.Domaine.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Persons.Queries.GetPersonByIdQuery
{
    public class GetPersonByIdQuery : IRequest<Person>
    {
        public Guid Id { get; private set; }
        public string Email { get; internal set; }

        public GetPersonByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
