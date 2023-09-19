using PrevisaoClimatica.Api.Extensions;
using Microsoft.Extensions.Options;
using PrevisaoClimatica.Api.Interfaces;
using System.Net;
using PrevisaoClimatica.Api.Models.DTO;
using PrevisaoClimatica.Api.Models;

namespace PrevisaoClimatica.Api.Services
{
    public class ClimaService : BaseService, IClimaService
    {
        private readonly HttpClient _httpClient;
        private readonly IAeroportoPrevisaoRepository _aeroportoPrevisaoRepository;
        private readonly ICidadePrevisaoRepository _cidadePrevisaoRepository;
        private readonly ILogsRepository _logsRepository;
        private readonly ILogger _logger;

        public ClimaService(HttpClient httpClient,
                              IOptions<AppSettings> settings,
                              IAeroportoPrevisaoRepository aeroportoPrevisaoRepository,
                              ICidadePrevisaoRepository cidadePrevisaoRepository,
                              ILogsRepository logsRepository,
                              INotificador notificador,
                              ILogger logger) : base(notificador)

        {
            httpClient.BaseAddress = new Uri(settings.Value?.CptecBrasilApiUrl ?? default);
            _httpClient = httpClient;

            _aeroportoPrevisaoRepository = aeroportoPrevisaoRepository;
            _cidadePrevisaoRepository = cidadePrevisaoRepository;
            _logsRepository = logsRepository;
            _logger = logger;
        }

        public async Task<CidadePrevisaoDTO> ObterClimaCidade(string nomeCidade)
        {
            try
            {
                _logger.LogInformation("Consultando id da cidade : " + nomeCidade);

                var cidadeId = ObterCidade(nomeCidade);

                _logger.LogInformation("Consultando prévisão da cidade : " + nomeCidade);

                var response = await _httpClient.GetAsync($"/api/cptec/v1/clima/previsao/{cidadeId}");

                TratarErrosResponse(response);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    await NotificarErroResponse(response);

                    return null;
                }

               var cidadePrevisao = await DeserializarObjetoResponse<CidadePrevisaoDTO>(response);

                _cidadePrevisaoRepository.Adicionar(MapCidadePrevisao(cidadePrevisao));

                _logger.LogInformation("Inserindo informações no banco : " + nomeCidade);

                return cidadePrevisao;
            }
            catch (Exception ex)
            {
                _logsRepository.Adicionar(MapLogs(ex));
                throw;
            }
        }

        public async Task<AeroportoPrevisaoDTO> ObterClimaAeroporto(string icao)
        {
            try
            {
                _logger.LogInformation("Consultando clima do aeroporto: " + icao);

                var response = await _httpClient.GetAsync($"/api/cptec/v1/clima/aeroporto/{icao}");

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    await NotificarErroResponse(response);

                    return null;
                }

                TratarErrosResponse(response);

                var aeroportoPrevisao = await DeserializarObjetoResponse<AeroportoPrevisaoDTO>(response);

                _aeroportoPrevisaoRepository.Adicionar(MapAeroportoPrevisao(aeroportoPrevisao));

                _logger.LogInformation("Inserindo informações no aeroporto : " + icao);

                return aeroportoPrevisao;
            }
            catch (Exception ex)
            {
                _logsRepository.Adicionar(MapLogs(ex));
                throw;
            }
        }

        public async Task<CidadeDTO> ObterCidade(string nomeCidade)
        {
            var response = await _httpClient.GetAsync($"/api/cptec/v1/cidade/{nomeCidade}");

            TratarErrosResponse(response);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                await NotificarErroResponse(response);

                return null;
            }

            var cidade = await DeserializarObjetoResponse<List<CidadeDTO>>(response);

            return cidade.First();
        }

        private async Task NotificarErroResponse(HttpResponseMessage response)
        {
            var mensagem = await DeserializarObjetoResponse<MensagemDTO>(response);

            _logger.LogError( $"Erro ao consulta : {response.RequestMessage.RequestUri} mensagem erro : {mensagem.type} - {mensagem.message}");

            Notificar($"{mensagem.type} - {mensagem.message}");
        }

        private AeroportoPrevisao MapAeroportoPrevisao(AeroportoPrevisaoDTO aeroportoPrevisaoDTO)
        {
            return new AeroportoPrevisao
            {
                Id = Guid.NewGuid(),
                CodigoIcao = aeroportoPrevisaoDTO.CodigoIcao,
                DescricaoClima = aeroportoPrevisaoDTO.DescricaoClima,
                Condicao = aeroportoPrevisaoDTO.Condicao,
                DirecaoVento = aeroportoPrevisaoDTO.DirecaoVento,
                PressaoAtmosferica = aeroportoPrevisaoDTO.PressaoAtmosferica,
                Tempo = aeroportoPrevisaoDTO.Temp,
                UltimaAtualizacao = aeroportoPrevisaoDTO.UltimaAtualizacao,
                Umidade = aeroportoPrevisaoDTO.Umidade,
                Vento = aeroportoPrevisaoDTO.Vento,
                Visibilidade = aeroportoPrevisaoDTO.Visibilidade
            };
        }

        private CidadePrevisao MapCidadePrevisao(CidadePrevisaoDTO cidadePrevisaoDTO)
        {
            var clima = cidadePrevisaoDTO.Clima.FirstOrDefault();

            return new CidadePrevisao
            {
                Id = Guid.NewGuid(),
                Cidade = cidadePrevisaoDTO.Cidade,
                Estado = cidadePrevisaoDTO.Estado,
                UltimaAtualizacao = cidadePrevisaoDTO.UltimaAtualizacao,
                Condicao = clima.Condicao,
                Data = clima.Data,
                DescricaoClima = clima.DescricaoClima,
                IndiceUV = clima.IndiceUV,
                Max = clima.Max,
                Min = clima.Min
            };
        }

        private Logs MapLogs(Exception ex)
        {
            return new Logs 
            { 
                Data = DateTime.Now,
                Id = Guid.NewGuid(),
                Mensagem = ex.ToString() 
            };
        }
    }
}
