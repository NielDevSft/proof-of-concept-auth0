using Authentication.Domain.Funcionarios.Habilidades;
using Authentication.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Persistence.Mapping
{
    public class HabilidadeMap : EntityTypeConfiguration<Habilidade>
    {
        public override void Map(EntityTypeBuilder<Habilidade> builder)
        {
            builder.ToTable("TB_Habilidade");

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);


        }
    }
}
