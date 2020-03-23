using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Data.Mappers
{
    public class LocatieConfiguration : IEntityTypeConfiguration<Locatie>
    {
        public void Configure(EntityTypeBuilder<Locatie> builder)
        {
            builder.ToTable("Locatie");
            builder.HasKey(p => p.Id);
        }
    }
}
