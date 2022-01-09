using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Garage_Program.Models
{
    public partial class GarageContext : DbContext
    {
        public GarageContext()
            : base("name=GarageContext")
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
