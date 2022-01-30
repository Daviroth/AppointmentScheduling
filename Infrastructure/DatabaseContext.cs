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
            // Appointment Mapping
            modelBuilder.Entity<Appointment>().ToTable("Appointments");
            modelBuilder.Entity<Appointment>().HasKey(a => a.Id);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Customer).WithMany(cust => cust.Appointments).HasForeignKey(a => a.CustomerId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Pet).WithMany(pet => pet.Appointments).HasForeignKey(a => a.PetId);

            // Customer Mapping
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().HasMany(cust => cust.Pets).WithOne(pet => pet.Owner).HasForeignKey(pet => pet.OwnerId);

            // Pet Mapping
            modelBuilder.Entity<Pet>().ToTable("Pet");
            modelBuilder.Entity<Pet>().HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
