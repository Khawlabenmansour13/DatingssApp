using DatingApp.Application.Persons.Commands.DeletePerson;
using DatingApp.Application.Persons.Responses;
using DatingApp.Infrastructure.Repositories.PersonRepository.PersonCommand;
using DatingApp.Infrastructure.Repositories.PersonRepository.PersonQuery;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Handlers
{
    public class DeletePersonHandler :  IRequestHandler<DeletePersonCommand, PersonResponse>
    {
        private readonly IPersonCommandRepository _personCommandRepository;
        private readonly IPersonQueryRepository _personQueryRepository;
        public DeletePersonHandler(IPersonCommandRepository personCommandRepository, IPersonQueryRepository personQueryRepository)
        {
            this._personCommandRepository = personCommandRepository;
            this._personQueryRepository = personQueryRepository;
        }
        public async Task<PersonResponse> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var PersonEntity = await _personQueryRepository.GetPersonByIdAsync(request.Id);

                await _personCommandRepository.DeleteAsync(PersonEntity);

            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return new PersonResponse() { Message = "Person information has been deleted!" };
        }
    }

}
