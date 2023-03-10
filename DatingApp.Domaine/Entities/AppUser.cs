using DatingApp.Domaine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Domaine.Entities
{
   public class AppUser:BaseEntity
    {
        
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
       // public byte[] PaawordHash { get; set; } 
       // public byte [] PasswordSalt { get; set; }
     
       


    }
}
