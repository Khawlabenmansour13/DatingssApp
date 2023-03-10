using DatingApp.Domaine.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Queries.GetAllUserByEmail
{
    public class GetUserByEmailQuery :IRequest<AppUser>
    {
        public string Email { get; private set; }

        public GetUserByEmailQuery(string email)
        {
            this.Email = email;
        }
    }
}
