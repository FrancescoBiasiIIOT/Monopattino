using ITS.Monopattino.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Server.Data.Detection_Repository
{
    public class ValleProjectContext : DbContext
    {
        public ValleProjectContext(DbContextOptions<ValleProjectContext> options) : base(options)
        {
            //costruttore fondamentale per poter utilizzare la stringa di connessione tramite dependency injection
        }
        //descrizione tabelle presente nel database:

        public DbSet<Detection> Detections { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Scooter> Scooters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detection>();
               // .HasOne(p => p.Scooter);
            modelBuilder.Entity<Rental>()
                .HasOne(p => p.Scooter);
            modelBuilder.Entity<Rental>()
                .HasOne(p => p.User);
        }
    }
}
