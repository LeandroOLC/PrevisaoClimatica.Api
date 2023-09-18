using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrevisaoClimatica.Api.Models;

namespace PrevisaoClimatica.Api.Data.Mappings
{
    public class LogsMapping : IEntityTypeConfiguration<Logs>
    {
        public void Configure(EntityTypeBuilder<Logs> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Mensagem);

            builder.ToTable("Logs");
        }
    }
}
