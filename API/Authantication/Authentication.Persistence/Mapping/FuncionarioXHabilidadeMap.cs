using Authentication.Domain.Funcionarios.FuncionarioXHabilidades;
using Authentication.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Persistence.Mapping
{
    public class FuncionarioXHabilidadeMap : EntityTypeConfiguration<FuncionarioXHabilidade>
    {
        public override void Map(EntityTypeBuilder<FuncionarioXHabilidade> builder)
        {
            builder.HasOne(e => e.IdFuncionarioNavigation)
    .WithMany(e => e.FuncionarioXHabilidades)
    .HasForeignKey(e => e.IdFuncionario)
    .OnDelete(DeleteBehavior.ClientSetNull)
    .HasConstraintName("FK_TB_FuncionarioXHabilidade_TB_Funcionario");

            builder.HasOne(e => e.IdHabilidadeNavigation)
   .WithMany(e => e.FuncionarioXHabilidades)
   .HasForeignKey(e => e.IdHabilidade)
   .OnDelete(DeleteBehavior.ClientSetNull)
   .HasConstraintName("FK_TB_FuncionarioXHabilidade_TB_Habilidade");
        }
    }
}
