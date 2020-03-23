using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Data.Mappers
{
    public class AttractieConfiguration : IEntityTypeConfiguration<Attractie>
    {
        public void Configure(EntityTypeBuilder<Attractie> builder)
        {
            builder.ToTable("Attractie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Naam)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.Omschrijving)
                .IsRequired();
        }
    }
}
