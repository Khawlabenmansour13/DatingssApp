using DatingApp.Application.Persons.Commands.CreatePerson;
using DatingApp.Application.Persons.Common.Mapper;
using DatingApp.Application.Persons.Responses;

using DatingApp.Domaine.Entities;
using DatingApp.Infrastructure.Repositories.PersonRepository.PersonCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Persons.Handlers
{
   public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, PersonResponse>
    {
        private readonly IPersonCommandRepository userCommandRepository;
        public CreatePersonHandler(IPersonCommandRepository userCommandRepository)
        {
            this.userCommandRepository = userCommandRepository;
        }
      public async Task<PersonResponse> Handle (CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var PersonEntity = PersonMapper.Mapper.Map<Person>(request);
            if (PersonEntity is null) 
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            var newPerson = await userCommandRepository.AddAsync(PersonEntity);
            var ResponseUser = PersonMapper.Mapper.Map<PersonResponse>(newPerson);
            return new PersonResponse

            {
                Status = "Success",
                Message = "Person added successfully"
            };

        } 

   

    }
}
