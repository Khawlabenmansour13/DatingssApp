using DatingApp.Application.Users.Queries.GetAllUser;
using DatingApp.Application.Users.Queries.GetAllUserByEmail;

using DatingApp.Domaine.Entities;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Handlers
{
  public class GetUserByEmailHandler : IRequestHandler <GetUserByEmailQuery, AppUser>
    {
        
            private readonly IMediator _mediator;

            public GetUserByEmailHandler(IMediator mediator)
            {
                _mediator = mediator;
            }
            public async Task<AppUser> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
            {
                var Users = await _mediator.Send(new GetAllUsersQuery());
                var selectedUser = Users.FirstOrDefault(x => x.Email.ToLower().Contains(request.Email.ToLower()));
                return selectedUser;
            }
        }
    
}
