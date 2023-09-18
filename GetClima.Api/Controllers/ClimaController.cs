using Microsoft.AspNetCore.Mvc;
using PrevisaoClimatica.Api.Interfaces;
using PrevisaoClimatica.Api.Models.DTO;
using PrevisaoClimatica.Api.Services;

namespace PrevisaoClimatica.Api.Controllers
{
    [Route("api/previsao-climatica")]
    [ApiController]
    public class ClimaController : MainController
    {
        public IClimaService _climaService { get; set; }

        public ClimaController(IClimaService climaService)
        {
            _climaService = climaService;
        }

        [HttpGet("cidade/{nome}")]
        public async Task<IActionResult> ObterPrevisaoCidade(string nome)
        {
            var codigoCidade = await ObterCodigoCidadePorNome(nome) ?? default;

            if (!OperacaoValida()) return CustomResponse();

            var previsao = await ObterPrevisaoCidadePorId(codigoCidade);

            if (!OperacaoValida()) return CustomResponse();

            return CustomResponse(previsao);
        }

        [HttpGet("aeroporto/{codigoIcao}")]
        public async Task<IActionResult> ObterPrevisaoAeroporto(string codigoIcao)
        {
            var previsao = await ObterPrevisaoAeroportoPorICAO(codigoIcao);

            if (!OperacaoValida()) return CustomResponse();

            return CustomResponse(previsao);
        }

        private async Task<int?> ObterCodigoCidadePorNome(string nome)
        {
            var cidade = await _climaService.ObterCidade(nome);

            if (cidade is null)
                AdicionarErroProcessamento("Nenhuma cidade não localizada");

            return cidade?.Id;
        }

        private async Task<CidadePrevisaoDTO> ObterPrevisaoCidadePorId(int id)
        {
            var previsao = await _climaService.ObterClimaCidade(id);

            if (previsao is null)
                AdicionarErroProcessamento("Cidade não localizada");

            return previsao;
        }

        private async Task<AeroportoPrevisaoDTO> ObterPrevisaoAeroportoPorICAO(string codigo)
        {
            var previsao = await _climaService.ObterClimaAeroporto(codigo);

            if (previsao is null)
                AdicionarErroProcessamento("Condições meteorológicas ou aeroporto não localizados");

            return previsao;
        }
    }
}
