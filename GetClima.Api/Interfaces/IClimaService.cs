using PrevisaoClimatica.Api.Models.DTO;

namespace PrevisaoClimatica.Api.Interfaces
{
    public interface IClimaService
    {
        Task<CidadePrevisaoDTO> ObterClimaCidade(int cidadeId);

        Task<AeroportoPrevisaoDTO> ObterClimaAeroporto(string icao);

        Task<CidadeDTO> ObterCidade(string nomeCidade);
    }
}
