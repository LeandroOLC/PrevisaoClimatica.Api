using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrevisaoClimatica.Api.Models;

namespace PrevisaoClimatica.Api.Data.Mappings
{
    public class AeroportoPrevisaoMapping : IEntityTypeConfiguration<AeroportoPrevisao>
    {
        public void Configure(EntityTypeBuilder<AeroportoPrevisao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CodigoIcao)
                  .HasColumnType("varchar(10)");

            builder.Property(c => c.Condicao)
                 .HasColumnType("varchar(100)");

            builder.Property(c => c.DescricaoClima)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.DirecaoVento)
                 .HasColumnType("int");

            builder.Property(c => c.PressaoAtmosferica)
                 .HasColumnType("int");

            builder.Property(c => c.Tempo)
                .HasColumnType("int");

            builder.Property(c => c.UltimaAtualizacao);

            builder.Property(c => c.Umidade)
               .HasColumnType("int");

            builder.Property(c => c.Vento)
                .HasColumnType("int");

            builder.Property(c => c.Visibilidade)
                  .HasColumnType("varchar(200)");

            builder.ToTable("AeroportoPrevisao");
        }
    }
}
