using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Domaine.Common
{
    public class BaseEntity 
    {
        [Key]

        public Guid Id { get; set; }
      
        public DateTime CreatedDate { get; set; }
     
        public DateTime ModifiedDate { get; private set; }

        public BaseEntity()
        {
            this.ModifiedDate = DateTime.Now;
        }
    }
}
