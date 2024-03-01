using Microsoft.EntityFrameworkCore;
using VeterinaryApp.Models;

namespace VeterinaryApp.Data
{
    public class VeterinaryAppContext : DbContext
    {

        public VeterinaryAppContext(DbContextOptions<VeterinaryAppContext> options) : base(options)
        {
        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }


      
    }
}



