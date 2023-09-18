using Microsoft.EntityFrameworkCore;
using PrevisaoClimatica.Api.Models;

namespace PrevisaoClimatica.Api.Data
{
    public class PrevisaoClimaticaContext : DbContext
    {
        public PrevisaoClimaticaContext(DbContextOptions<PrevisaoClimaticaContext> options)
        : base(options) { }


        public DbSet<Logs> Logs { get; set; }
        public DbSet<AeroportoPrevisao> AeroportoPrevisao { get; set; }
        public DbSet<CidadePrevisao> CidadePrevisao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrevisaoClimaticaContext).Assembly);
        }
    }
}
