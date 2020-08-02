using System;
using GRADAPP.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GRADAPP.Infrastructure.Data
{
    
        public class AppDbContext : DbContext
        {
            public DbSet<Family> Members { get; set; }
            public DbSet<Activity> Activities { get; set; }
            // NOTE that we don't have to define a Users DbSet. It is given to us by IdentityDbContext.

            // This method runs once when the DbContext is first used.
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=../gradapp/GRADAPP.Infrastructure\familyapp.db");
            }

            // This method runs once when the DbContext is first used.
            // It's a place where we can customize how EF Core maps our
            // model to the database. 
            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

            builder.Entity<Family>().HasData(
                   new Family { Id = 1, Name = "John" }
               );

            builder.Entity<Activity>().HasData(
                    new Activity { Id = 1, Name = "school", Date = "7/31/20", FamilyId = 1,}
                    
                );

               

                

            }
        }
    
}
