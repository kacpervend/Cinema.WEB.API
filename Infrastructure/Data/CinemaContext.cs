using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace Infrastructure.Data
{
    public class CinemaContext : DbContext
    {
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Address> Address { get; set; }

        public CinemaContext(DbContextOptions options) : base(options)
        {

        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(x => x.Entity == typeof(Entity) && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                ((Entity)entry.Entity).ModifiedDate = DateTime.Now;
                ((Entity)entry.Entity).ModifiedById = 1;

                if (entry.State == EntityState.Added)
                {
                    ((Entity)entry.Entity).CreatedDate = DateTime.Now;
                    ((Entity)entry.Entity).CreatedById = 1;
                }
            }

            return base.SaveChanges();
        }
    }
}
