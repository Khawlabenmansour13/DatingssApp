
using DatingApp.Application.Persons.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommand :IRequest<PersonResponse>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
       

      public UpdatePersonCommand(string firstName, string lastName, DateTime birthDate, string phoneNumber, string email, string address, Guid id)
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
