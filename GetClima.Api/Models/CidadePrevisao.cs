using System.Text.Json.Serialization;

namespace PrevisaoClimatica.Api.Models
{
    public class CidadePrevisao
    {
        public Guid Id { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public DateTime UltimaAtualizacao { get; set; }

        public DateTime Data { get; set; }

        public string Condicao { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }

        public int IndiceUV { get; set; }

        public string DescricaoClima { get; set; }
    }
}
