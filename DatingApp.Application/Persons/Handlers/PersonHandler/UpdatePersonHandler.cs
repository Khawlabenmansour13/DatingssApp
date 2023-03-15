
using DatingApp.Application.Persons.Commands.UpdatePerson;
using DatingApp.Application.Persons.Common.Mapper;
using DatingApp.Application.Persons.Responses;


using DatingApp.Domaine.Entities;
using DatingApp.Infrastructure.Repositories.PersonRepository.PersonCommand;
using DatingApp.Infrastructure.Repositories.PersonRepository.PersonQuery;

using MediatR;

namespace DatingApp.Application.Users.Handlers
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, PersonResponse>
    {
        private readonly IPersonCommandRepository _personCommandRepository;
        private readonly IPersonQueryRepository _personQueryRepository;
        public UpdatePersonHandler(IPersonCommandRepository personCommandRepository, IPersonQueryRepository personQueryRepository)
        {
            _personCommandRepository = personCommandRepository;
            _personQueryRepository = personQueryRepository;
        }
        public async Task<PersonResponse> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var UserEntity = PersonMapper.Mapper.Map<Person>(request);


            if (UserEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _personCommandRepository.UpdateAsync(UserEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedUser = await _personQueryRepository.GetPersonByIdAsync(request.Id);
            var ResponseUser = PersonMapper.Mapper.Map<Person>(modifiedUser);


            return new PersonResponse

            {
                Status = "Success",
                Message = "User Updated successfully"
            };
        }
    }
}
