using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructre.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortifioloItem>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            //some orders intial data
            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    Id = Guid.NewGuid(),
                    Picture = "1.jpg",
                    Name = "Maher ali",
                    Profile = "MaherAli.com"
                });
        }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<PortifioloItem> PortifioloItem { get; set; }

    }
}
