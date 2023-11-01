using Authentication.Domain.Funcionarios;
using Authentication.Domain.Funcionarios.Enums;
using Authentication.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Persistence.Mapping
{
    public class FuncionarioMap : EntityTypeConfiguration<Funcionario>
    {
        public override void Map(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TB_Funcionario");

            builder.Property(e => e.NomeCompleto)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.DataNascimento)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsRequired(false)
                .IsUnicode(false);

            builder.Property<SexoEnum>(e => e.Sexo)
                .HasColumnType("tinyint")
                .IsRequired();
        }
    }
}
