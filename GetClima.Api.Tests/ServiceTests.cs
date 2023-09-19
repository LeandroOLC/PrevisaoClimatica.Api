using PrevisaoClimatica.Api.Data.Repository;
using PrevisaoClimatica.Api.Models;
using System.Net.Sockets;
using Moq;
using Moq.AutoMock;
using PrevisaoClimatica.Api.Interfaces;
using PrevisaoClimatica.Api.Services;
using PrevisaoClimatica.Api.Extensions;
using static Dapper.SqlMapper;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using static System.Net.WebRequestMethods;

namespace GetClima.Api.Tests
{
    public class ServiceTests
    {

        [Fact(DisplayName = "Adicionar aeroportoPrevisao com Sucesso")]
        public async void AeroportoPrevisaoService_Adicionar()
        {
            var aeroportoPrevisao = new AeroportoPrevisao
            {
                CodigoIcao = "SMDR",
                Condicao = "ps",
                DescricaoClima = "Predomínio de Sol",
                DirecaoVento = 90,
                Id = Guid.NewGuid(),
                PressaoAtmosferica = 1014,
            };

            var mocker = new AutoMocker();

            var _aeroportoPrevisaoRepository = new Mock<IAeroportoPrevisaoRepository>();
            var _logsRepository = new Mock<ILogsRepository>();
            var _cidadePrevisaoRepository = new Mock<ICidadePrevisaoRepository>();
            var _httpClient = new Mock<HttpClient>();
            var _appSettings = new Mock<IOptions<AppSettings>>();
            var _notificador = new Mock<INotificador>();
            var _logger = new Mock<ILogger>();

            var clienteService = new ClimaService(_httpClient.Object,
                _appSettings.Object,
                _aeroportoPrevisaoRepository.Object,
                _cidadePrevisaoRepository.Object,
                _logsRepository.Object,
                _notificador.Object,
                _logger.Object);

            await clienteService.ObterClimaCidade("SDFT");

            mocker.GetMock<IAeroportoPrevisaoRepository>().Verify(r => r.Adicionar(aeroportoPrevisao), Times.Once);
        }

        [Fact(DisplayName = "Adicionar aeroportoPrevisao com Sucesso")]
        public async void CidadePrevisaoService_Adicionar()
        {
            var cidadePrevisao = new CidadePrevisao
            {
                Cidade = "Palmas",
                Condicao = "PD",
                Data = DateTime.Now,
                DescricaoClima = "Predomínio de Sol",
                IndiceUV = 213,
                Max = 12,
                Min = 11,
            };

            var mocker = new AutoMocker();

            var _aeroportoPrevisaoRepository = new Mock<IAeroportoPrevisaoRepository>();
            var _logsRepository = new Mock<ILogsRepository>();
            var _cidadePrevisaoRepository = new Mock<ICidadePrevisaoRepository>();
            var _httpClient = new Mock<HttpClient>();
            var _appSettings = new Mock<IOptions<AppSettings>>();
            var _notificador = new Mock<INotificador>();
            var _logger = new Mock<ILogger>();

            var clienteService = new ClimaService(_httpClient.Object,
                _appSettings.Object,
                _aeroportoPrevisaoRepository.Object,
                _cidadePrevisaoRepository.Object,
                _logsRepository.Object,
                _notificador.Object,
                _logger.Object);

            await clienteService.ObterClimaAeroporto("SDRT");

            mocker.GetMock<ICidadePrevisaoRepository>().Verify(r => r.Adicionar(cidadePrevisao), Times.Once);

        }
    }
}