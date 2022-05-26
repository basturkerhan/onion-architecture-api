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
    public class ChairConfiguration : IEntityTypeConfiguration<Chair>
    {
        public void Configure(EntityTypeBuilder<Chair> builder)
        {
            builder
                .HasOne(x => x.Hall)
                .WithMany(x => x.Chairs)
                .HasForeignKey(x => x.HallId);
            builder
                .HasOne(x => x.AppUser)
                .WithMany(x => x.Chairs)
                .HasForeignKey(x => x.AppUserId);
        }
    }
}
