using System.Text.Json.Serialization;

namespace PrevisaoClimatica.Api.Models.DTO
{

    public class CidadeDTO
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }

}
