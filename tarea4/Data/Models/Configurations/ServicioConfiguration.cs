using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Configurations
{
    public class ServicioConfiguration : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
           
            builder
                .ToTable("T_servicios")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("id_servicio");
            builder.Property(p => p.Nombre).HasColumnName("nombre");
            builder.Property(p => p.Costo).HasColumnName("costo");
            builder.Property(p => p.EnPromocion).HasColumnName("en_promocion");
            builder.Property(p => p.FechaBaja).HasColumnName("fecha_baja").IsRequired(false);
            builder.Property(p => p.MotivoBaja).HasColumnName("motivo_baja").IsRequired(false);
        }
    }
}
