using PrevisaoClimatica.Api.Extensions;
using Microsoft.Extensions.Options;
using PrevisaoClimatica.Api.Interfaces;
using System.Net;
using PrevisaoClimatica.Api.Models.DTO;
using PrevisaoClimatica.Api.Models;

namespace PrevisaoClimatica.Api.Services
{
    public class ClimaService : Service, IClimaService
    {
        private readonly HttpClient _httpClient;
        private readonly IAeroportoPrevisaoRepository _aeroportoPrevisaoRepository;
        private readonly ICidadePrevisaoRepository _cidadePrevisaoRepository;
        private readonly ILogsRepository _logsRepository;

        public ClimaService(HttpClient httpClient,
                              IOptions<AppSettings> settings,
                              IAeroportoPrevisaoRepository aeroportoPrevisaoRepository,
                              ICidadePrevisaoRepository cidadePrevisaoRepository,
                              ILogsRepository logsRepository)
        {
            httpClient.BaseAddress = new Uri(settings.Value?.CptecBrasilApiUrl ?? default);
            _httpClient = httpClient;

            _aeroportoPrevisaoRepository = aeroportoPrevisaoRepository;
            _cidadePrevisaoRepository = cidadePrevisaoRepository;
            _logsRepository = logsRepository;
        }

        public async Task<CidadePrevisaoDTO> ObterClimaCidade(int cidadeId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/cptec/v1/clima/previsao/{cidadeId}");

                if (response.StatusCode == HttpStatusCode.NotFound) return null;

                TratarErrosResponse(response);

                var cidadePrevisao = await DeserializarObjetoResponse<CidadePrevisaoDTO>(response);

                _cidadePrevisaoRepository.Adicionar(MapCidadePrevisao(cidadePrevisao));

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
                var response = await _httpClient.GetAsync($"/api/cptec/v1/clima/aeroporto/{icao}");

                if (response.StatusCode == HttpStatusCode.NotFound) return null;

                TratarErrosResponse(response);

                var aeroportoPrevisao = await DeserializarObjetoResponse<AeroportoPrevisaoDTO>(response);

                _aeroportoPrevisaoRepository.Adicionar(MapAeroportoPrevisao(aeroportoPrevisao));

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

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            TratarErrosResponse(response);

            var cidade = await DeserializarObjetoResponse<List<CidadeDTO>>(response);

            return cidade.First();
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
