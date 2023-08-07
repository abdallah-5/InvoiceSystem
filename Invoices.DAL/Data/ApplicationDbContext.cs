using Invoices.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoices.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("YourConnectionStringHere", options => options.CommandTimeout(60));
        //}
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
    }
}
