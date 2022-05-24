using Erhan.MovieTicketSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Persistence.Configurations
{
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasIndex(x => new
            {
                x.GenreId,
                x.MovieId
            }).IsUnique();

            builder
                .HasOne(x => x.Movie)
                .WithMany(x => x.MovieGenres)
                .HasForeignKey(x => x.MovieId);

            builder
                .HasOne(x => x.Genre)
                .WithMany(x => x.MovieGenres)
                .HasForeignKey(x => x.GenreId);
        }
    }
}
