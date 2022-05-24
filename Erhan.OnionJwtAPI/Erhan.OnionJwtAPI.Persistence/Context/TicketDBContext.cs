using Erhan.MovieTicketSystem.Domain;
using Erhan.MovieTicketSystem.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Persistence.Context
{
    public class TicketDBContext : DbContext
    {
        public TicketDBContext(DbContextOptions<TicketDBContext> options) : base(options) {}

        public DbSet<AppRole> AppRole { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Hall> Hall { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<MovieHall> MovieHall { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ChairConfiguration());
            modelBuilder.ApplyConfiguration(new HallConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieHallConfiguration());
        }

    }
}
