using Microsoft.AspNetCore.Mvc;
using PrevisaoClimatica.Api.Controllers;
using PrevisaoClimatica.Api.Interfaces;

namespace PrevisaoClimatica.Api.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/previsao-climatica")]
    [ApiController]
    public class ClimaController : MainController
    {
        public IClimaService _climaService { get; set; }

        public ClimaController(IClimaService climaService,
                               INotificador notificador) : base(notificador)
        {
            _climaService = climaService;
        }

        [HttpGet("cidade/{nome}")]
        public async Task<IActionResult> ObterPrevisaoCidade(string nome)
        {
            var previsao = await _climaService.ObterClimaCidade(nome);

            if (!OperacaoValida()) return CustomResponse();

            return CustomResponse(previsao);
        }

        [HttpGet("aeroporto/{codigoIcao}")]
        public async Task<IActionResult> ObterPrevisaoAeroporto(string codigoIcao)
        {
            var previsao = await _climaService.ObterClimaAeroporto(codigoIcao);

            if (!OperacaoValida()) return CustomResponse();

            return CustomResponse(previsao);
        }
    }
}
