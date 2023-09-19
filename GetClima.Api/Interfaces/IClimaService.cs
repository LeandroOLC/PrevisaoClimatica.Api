using PrevisaoClimatica.Api.Models.DTO;

namespace PrevisaoClimatica.Api.Interfaces
{
    public interface IClimaService
    {
        Task<CidadePrevisaoDTO> ObterClimaCidade(string nomeCidade);

        Task<AeroportoPrevisaoDTO> ObterClimaAeroporto(string icao);

        Task<CidadeDTO> ObterCidade(string nomeCidade);
    }
}
