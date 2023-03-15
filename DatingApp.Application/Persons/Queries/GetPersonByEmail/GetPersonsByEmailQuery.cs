using DatingApp.Domaine.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Persons.Queries.GetAllPersonsByEmail
{
    public class GetPersonsByEmailQuery :IRequest<Person>
    {
        public string Email { get; private set; }

        public GetPersonsByEmailQuery(string email)
        {
            this.Email = email;
        }
    }
}
