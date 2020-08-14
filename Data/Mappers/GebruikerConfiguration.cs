using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Data.Mappers
{
    public class GebruikerConfiguration : IEntityTypeConfiguration<Gebruiker>

    {
        public void Configure(EntityTypeBuilder<Gebruiker> builder)
        {
            builder.HasKey(m => m.GebruikerId);
            builder.Property(p => p.Voornaam)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(m => m.Achternaam)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasMany(m => m.IngeschrevenEvenementen)
                .WithOne()
                .HasForeignKey("GebruikerId");

        }
    }
}
