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
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(120);
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(120);
        }
    }
}
