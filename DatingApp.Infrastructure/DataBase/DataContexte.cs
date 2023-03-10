
using DatingApp.Domaine.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataBase
{
    public class DataContexte : DbContext
    {
        public DataContexte(DbContextOptions<DataContexte> options)
         : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

       // public DbSet<AppUser> Users { get; set; }
       public DbSet<AppUser>Users { get; set; } 

    }

}
