using DatingApp.Application.Users.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Commands.DeleteUser
{
    public  class DeleteUserCommand :IRequest<UserResponse>
    {
        public Guid Id { get; set; }

        public DeleteUserCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
}
