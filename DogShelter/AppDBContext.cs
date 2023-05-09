using DogShelter.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Security.Claims;

namespace DogShelter
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                    .UseSqlServer("Server=MARIA\\SQLEXPRESS;Database=DogShelter;User Id=maria;Password=1234;TrustServerCertificate = True;")
                    .LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Dog> Dog{ get; set; }
        public DbSet<Adoption> Adoption { get; set; }
        public DbSet<Details> Details { get; set; }
        public DbSet<Donation> Donation { get; set; }

    }
}
