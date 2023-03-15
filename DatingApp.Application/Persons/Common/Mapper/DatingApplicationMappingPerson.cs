using AutoMapper;
using DatingApp.Application.Persons.Commands.CreatePerson;
using DatingApp.Application.Persons.Commands.UpdatePerson;
using DatingApp.Application.Persons.Responses;

using DatingApp.Application.Users.Handlers;

using DatingApp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Persons.Common.Mapper
{
    public class DatingApplicationMappingPerson :Profile
    {

        public DatingApplicationMappingPerson() {
            CreateMap<Person, PersonResponse>().ReverseMap();
            CreateMap<Person, CreatePersonCommand>().ReverseMap();
            CreateMap<Person, UpdatePersonCommand>().ReverseMap();
        }
       
       
    }
}
