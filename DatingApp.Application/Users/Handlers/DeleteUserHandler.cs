using DatingApp.Application.Users.Commands.DeleteUser;
using DatingApp.Application.Users.Responses;
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
    public class DeleteUserHandler :  IRequestHandler<DeleteUserCommand, UserResponse>
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        public DeleteUserHandler(IUserCommandRepository userCommandRepository, IUserQueryRepository userQueryRepository)
        {
            this._userCommandRepository = userCommandRepository;
            this._userQueryRepository = userQueryRepository;
        }
        public async Task<UserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserEntity = await _userQueryRepository.GetUserByIdAsync(request.Id);

                await _userCommandRepository.DeleteAsync(UserEntity);

            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return new UserResponse() { Message = "User information has been deleted!" };
        }
    }

}
