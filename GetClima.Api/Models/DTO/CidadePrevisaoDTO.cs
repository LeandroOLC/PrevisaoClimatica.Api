using System.Text.Json.Serialization;

namespace PrevisaoClimatica.Api.Models.DTO
{

    public class CidadePrevisaoDTO
    {
        [JsonPropertyName("cidade")]
        public string Cidade { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("atualizado_em")]
        public DateTime UltimaAtualizacao { get; set; }

        [JsonPropertyName("clima")]
        public Clima[] Clima { get; set; }
    }

    public class Clima
    {
        [JsonPropertyName("data")]
        public DateTime Data { get; set; }

        [JsonPropertyName("condicao")]
        public string Condicao { get; set; }

        [JsonPropertyName("min")]
        public int Min { get; set; }

        [JsonPropertyName("max")]
        public int Max { get; set; }

        [JsonPropertyName("indice_uv")]
        public int IndiceUV { get; set; }

        [JsonPropertyName("condicao_desc")]
        public string DescricaoClima { get; set; }
    }

}
