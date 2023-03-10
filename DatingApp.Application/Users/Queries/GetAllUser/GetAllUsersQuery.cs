using DatingApp.Domaine.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Queries.GetAllUser
{
    public class GetAllUsersQuery : IRequest<List<AppUser>>
    {

    }
}
