using DatingApp.Application.Users.Commands.DeleteUser;
using DatingApp.Application.Users.Commands.UpdateUser;
using DatingApp.Application.Users.Common.Mapper;
using DatingApp.Application.Users.Responses;
using DatingApp.Domaine.Entities;
using DatingApp.Infrastructure.Repositories.UserRepository.UserCommand;
using DatingApp.Infrastructure.Repositories.UserRepository.UserQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Handlers
{
   public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserResponse>
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        public UpdateUserHandler(IUserCommandRepository userCommandRepository, IUserQueryRepository userQueryRepository)
        {
            this._userCommandRepository = userCommandRepository;
            this._userQueryRepository = userQueryRepository;
        }
       public async Task<UserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var UserEntity = UserMapper.Mapper.Map<AppUser>(request);


            if (UserEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _userCommandRepository.UpdateAsync(UserEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedQuestion = await _userQueryRepository.GetUserByIdAsync(request.Id);
            var QuestionResponse = UserMapper.Mapper.Map<AppUser>(modifiedQuestion);


            return new UserResponse

            {
                Status = "Success",
                Message = "User Updated  successfully"
            };
        }
    }
}
