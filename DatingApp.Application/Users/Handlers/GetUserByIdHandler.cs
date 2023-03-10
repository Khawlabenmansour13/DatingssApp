
using DatingApp.Application.Users.Queries.GetAllUser;
using DatingApp.Application.Users.Queries.GetUserByIdQuery;
using DatingApp.Domaine.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, AppUser>
    {
        private readonly IMediator _mediator;

        public GetUserByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<AppUser> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var Users = await _mediator.Send(new GetAllUsersQuery());
            var selectedUser = Users.FirstOrDefault(x => x.Id == request.Id);
            return selectedUser;
        }
    }
}
