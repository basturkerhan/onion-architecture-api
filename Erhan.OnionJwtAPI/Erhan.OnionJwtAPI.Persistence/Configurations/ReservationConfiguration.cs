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
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasIndex(x => new
            {
                x.ChairId,
                x.ReservationDate
            }).IsUnique();

            builder
                .HasOne(x => x.Chair)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.ChairId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.AppUser)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
