using System.Text.Json.Serialization;

namespace PrevisaoClimatica.Api.Models
{
    public class AeroportoPrevisao
    {
        public Guid Id { get; set; }

        public string CodigoIcao { get; set; }

        public DateTime UltimaAtualizacao { get; set; }

        public int PressaoAtmosferica { get; set; }

        public string Visibilidade { get; set; }

        public int Vento { get; set; }

        public int DirecaoVento { get; set; }

        public int Umidade { get; set; }

        public string Condicao { get; set; }

        public string DescricaoClima { get; set; }

        public int Tempo { get; set; }
    }

}
