using System.Text.Json.Serialization;

namespace PrevisaoClimatica.Api.Models.DTO
{
    public class AeroportoPrevisaoDTO
    {
        [JsonPropertyName("codigo_icao")]
        public string CodigoIcao { get; set; }

        [JsonPropertyName("atualizado_em")]
        public DateTime UltimaAtualizacao { get; set; }

        [JsonPropertyName("pressao_atmosferica")]
        public int PressaoAtmosferica { get; set; }

        [JsonPropertyName("visibilidade")]
        public string Visibilidade { get; set; }

        [JsonPropertyName("vento")]
        public int Vento { get; set; }

        [JsonPropertyName("direcao_vento")]
        public int DirecaoVento { get; set; }

        [JsonPropertyName("umidade")]
        public int Umidade { get; set; }

        [JsonPropertyName("condicao")]
        public string Condicao { get; set; }

        [JsonPropertyName("condicao_Desc")]
        public string DescricaoClima { get; set; }

        [JsonPropertyName("temp")]
        public int Temp { get; set; }
    }

}
