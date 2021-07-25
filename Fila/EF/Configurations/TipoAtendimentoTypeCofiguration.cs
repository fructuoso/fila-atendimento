using Fila.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fila.EF.Configurations
{
    public class TipoAtendimentoTypeCofiguration : IEntityTypeConfiguration<TipoAtendimento>
    {
        public void Configure(EntityTypeBuilder<TipoAtendimento> builder)
        {
            builder.Property(o => o.Tipo).HasMaxLength(20).IsRequired();
            builder.Property(o => o.UltimoNumero);

            builder.HasKey(o => o.Tipo);
        }
    }
}
