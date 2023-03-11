using DatingApp.Application.Users.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand :IRequest<UserResponse>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
       

      public UpdateUserCommand(string firstName, string lastName, DateTime birthDate, string phoneNumber, string email, string address, Guid id)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
           Id = id;
        }
    }
}
