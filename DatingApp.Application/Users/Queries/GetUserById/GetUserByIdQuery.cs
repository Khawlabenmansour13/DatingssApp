using DatingApp.Domaine.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Queries.GetUserByIdQuery
{
    public class GetUserByIdQuery : IRequest<AppUser>
    {
        public Guid Id { get; private set; }
        public string Email { get; internal set; }

        public GetUserByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
