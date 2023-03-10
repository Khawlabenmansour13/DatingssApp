using DatingApp.Application.Users.Responses;
using MediatR;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public NpgsqlDateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public CreateUserCommand(string firstName, string lastName, NpgsqlDateTime birthDate, string phoneNumber, string email, string address)
        { 
            FirstName = firstName;          
            LastName = lastName;    
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
               
        }
    }
}
