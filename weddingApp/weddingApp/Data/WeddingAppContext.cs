using Microsoft.EntityFrameworkCore;
using weddingApp.Model.Entities;

namespace weddingApp.Data
{
    public class WeddingAppContext :DbContext
    {
        public WeddingAppContext(DbContextOptions<WeddingAppContext> option): base(option) { }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Couple> Couples { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<WeddingService> WeddingServices { get; set; }
    }
}
