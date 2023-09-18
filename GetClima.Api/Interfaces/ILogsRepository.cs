using PrevisaoClimatica.Api.Models;

namespace PrevisaoClimatica.Api.Interfaces
{
    public interface ILogsRepository
    {
        void Adicionar(Logs logs);
    }
}