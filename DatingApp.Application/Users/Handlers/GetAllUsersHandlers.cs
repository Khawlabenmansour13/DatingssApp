using DatingApp.Application.Users.Queries.GetAllUser;
using DatingApp.Domaine.Entities;
using DatingApp.Infrastructure.Repositories.UserRepository.UserQuery;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Handlers
{
    public class GetAllUsersHandlers : IRequestHandler<GetAllUsersQuery, List<AppUser>>
    {
       
            private readonly IUserQueryRepository _userQueryRepository;

            public GetAllUsersHandlers(IUserQueryRepository _userQueryRepository)
            {
               this._userQueryRepository = _userQueryRepository;
            }
            public async Task<List<AppUser>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                return (List<AppUser>)await _userQueryRepository.GetAllUsersAsync();
            }
        
    }
}
