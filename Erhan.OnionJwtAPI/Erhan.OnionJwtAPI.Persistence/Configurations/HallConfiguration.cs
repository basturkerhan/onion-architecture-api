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
    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.Property(x => x.Hallname).IsRequired().HasMaxLength(100);
        }
    }
}
