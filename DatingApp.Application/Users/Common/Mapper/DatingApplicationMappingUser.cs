using AutoMapper;
using DatingApp.Application.Users.Commands.CreateUser;
using DatingApp.Application.Users.Commands.UpdateUser;
using DatingApp.Application.Users.Handlers;
using DatingApp.Application.Users.Responses;
using DatingApp.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Common.Mapper
{
    public class DatingApplicationMappingUser :Profile
    {

        public DatingApplicationMappingUser() {
            CreateMap<AppUser, UserResponse>().ReverseMap();
            CreateMap<AppUser, CreateUserCommand>().ReverseMap();
            CreateMap<AppUser, UpdateUserCommand>().ReverseMap();
        }
       
       
    }
}
