using DatingApp.Application.Persons.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Persons.Commands.DeletePerson
{
    public  class DeletePersonCommand :IRequest<PersonResponse>
    {
        public Guid Id { get; set; }

        public DeletePersonCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
}
