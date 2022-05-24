using Erhan.MovieTicketSystem.Application.Enums;
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
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasIndex(x => x.Username).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Username).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Fullname).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.GenderId).HasDefaultValue(GenderType.Unknown);

            builder
                .HasOne(x => x.Gender)
                .WithMany(x => x.AppUsers)
                .HasForeignKey(x => x.GenderId);

            builder
                .HasOne(x => x.AppRole)
                .WithMany(x => x.AppUsers)
                .HasForeignKey(x => x.AppRoleId);
        }
    }
}
