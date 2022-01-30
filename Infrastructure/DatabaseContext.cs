using Microsoft.EntityFrameworkCore;
using AppointmentScheduling.Data;

namespace AppointmentScheduling.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        #region Constructor

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        #endregion

        #region Properties

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Pet> Pets { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().ToTable("Appointments");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Pet>().ToTable("Pet");
        }
    }
}
