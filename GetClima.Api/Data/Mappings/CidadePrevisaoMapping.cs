using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrevisaoClimatica.Api.Models;

namespace PrevisaoClimatica.Api.Data.Mappings
{
    public class CidadePrevisaoMapping : IEntityTypeConfiguration<CidadePrevisao>
    {
        public void Configure(EntityTypeBuilder<CidadePrevisao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Min)
                 .HasColumnType("int");

            builder.Property(c => c.Condicao)
                 .HasColumnType("varchar(100)");

            builder.Property(c => c.DescricaoClima)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Estado)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Cidade)
               .HasColumnType("varchar(150)");

            builder.Property(c => c.Data);

            builder.Property(c => c.UltimaAtualizacao);

            builder.Property(c => c.IndiceUV)
               .HasColumnType("int");

            builder.Property(c => c.Min)
                 .HasColumnType("int");

            builder.ToTable("CidadePrevisao");
        }
    }
}
