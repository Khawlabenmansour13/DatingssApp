using DatingApp.Application.Users.Commands.CreateUser;
using DatingApp.Application.Users.Common.Mapper;
using DatingApp.Application.Users.Responses;
using DatingApp.Domaine.Entities;
using DatingApp.Infrastructure.Repositories.UserRepository.UserCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Handlers
{
   public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly IUserCommandRepository userCommandRepository;
        public CreateUserHandler(IUserCommandRepository userCommandRepository)
        {
            this.userCommandRepository = userCommandRepository;
        }
      public async Task<UserResponse> Handle (CreateUserCommand request, CancellationToken cancellationToken)
        {
            var UserEntity = UserMapper.Mapper.Map<AppUser>(request);
            if (UserEntity is null) 
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            var newUser = await userCommandRepository.AddAsync(UserEntity);
            var ResponseUser = UserMapper.Mapper.Map<UserResponse>(newUser);
            return new UserResponse

            {
                Status = "Success",
                Message = "User added successfully"
            };

        } 

   

    }
}
