using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace webapp_travel_agency.Models
{
    public class VoyageContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<PacchettoViaggio> PacchettiViaggio { get; set; }
        public DbSet<Destination> Destinations { get; set; }

        public VoyageContext()
        {

        }

        public VoyageContext(DbContextOptions<VoyageContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Data Source=localhost;Initial Catalog=db-viaggi;Integrated Security=True";
          // la stringa di connsessione la si trova clicando sul db proprietà
            optionsBuilder.UseSqlServer(conn);
        }
    }
}
