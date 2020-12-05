using FlightSchedule.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightSchedule.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<City> Cities { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}