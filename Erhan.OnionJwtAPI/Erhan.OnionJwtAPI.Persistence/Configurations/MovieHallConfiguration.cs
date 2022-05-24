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
    public class MovieHallConfiguration : IEntityTypeConfiguration<MovieHall>
    {
        public void Configure(EntityTypeBuilder<MovieHall> builder)
        {
            builder.HasIndex(x => new
            {
                x.HallId,
                x.MovieId
            }).IsUnique();

            builder
                .HasOne(x => x.Movie)
                .WithMany(x => x.MovieHalls)
                .HasForeignKey(x => x.MovieId);

            builder
                .HasOne(x => x.Hall)
                .WithMany(x => x.MovieHalls)
                .HasForeignKey(x => x.HallId);
        }
    }
}
