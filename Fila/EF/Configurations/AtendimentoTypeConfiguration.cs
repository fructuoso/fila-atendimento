using Fila.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fila.EF.Configurations
{
    public class AtendimentoTypeConfiguration : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.Numero).IsRequired();
            builder.Property(o => o.Nome).HasMaxLength(50).IsRequired();
            builder.Property(o => o.TipoAtendimentoId).HasMaxLength(20).IsRequired();
            builder.Property(o => o.Status).HasMaxLength(20).IsRequired();
            builder.Property(o => o.DataHoraSolicitacao);

            builder.HasOne(o => o.TipoAtendimento)
                .WithMany()
                .HasForeignKey(o => o.TipoAtendimentoId);

            builder.HasKey(o => o.Id);
        }
    }
}
