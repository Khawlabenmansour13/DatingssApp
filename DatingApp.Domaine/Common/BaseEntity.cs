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
        [NotMapped]
        public NpgsqlDateTime CreatedDate { get; set; }
        [NotMapped]
        public NpgsqlDateTime ModifiedDate { get; private set; }

        public BaseEntity()
        {
            this.ModifiedDate = NpgsqlDateTime.Now;
        }
    }
}
