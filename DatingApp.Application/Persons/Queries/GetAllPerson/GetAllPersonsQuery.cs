using DatingApp.Domaine.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Persons.Queries.GetAllPerson
{
    public class GetAllPersonsQuery : IRequest<List<Person>>
    {

    }
}
