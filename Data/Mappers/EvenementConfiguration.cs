using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Data.Mappers
{
    public class EvenementConfiguration : IEntityTypeConfiguration<Evenement>
    {
        public void Configure(EntityTypeBuilder<Evenement> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasMany(m => m.Attracties)
                .WithOne()
                .HasForeignKey("EvenementId")
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(m => m.Locatie)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(p => p.NaamEvent)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasMany(p => p.Deelnemers)
                .WithOne()
                .HasForeignKey("EvenementId");
        }
    }
}
