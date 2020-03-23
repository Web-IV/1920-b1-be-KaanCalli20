using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Data.Mappers
{
    public class IngeschrevenEvenementConfiguration : IEntityTypeConfiguration<IngeschrevenEvenement>

    {
        public void Configure(EntityTypeBuilder<IngeschrevenEvenement> builder)
        {
            builder.HasKey(p => new { p.GebruikerId, p.EvenementId });
            builder.HasOne(p=>p.Gebruiker)
                .WithMany(m=>m.IngeschrevenEvenementen)
                .HasForeignKey(f => f.GebruikerId);
            builder.HasOne(p => p.Evenement)
                .WithMany(m => m.IngeschrevenGebruikers)
                .HasForeignKey(m => m.EvenementId);
        }
    }
}
