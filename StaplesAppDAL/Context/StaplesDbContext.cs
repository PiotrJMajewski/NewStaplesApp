using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StaplesAppDAL.Models;

namespace StaplesAppDAL.Context
{
    public class StaplesDbContext : DbContext
    {
        public StaplesDbContext() : base("StaplesDatabase")
        {
            Database.SetInitializer<StaplesDbContext>(null);
            Database.CreateIfNotExists();
        }

        public DbSet<Person> PersonBasicInformation { get; set; }
    }
}
