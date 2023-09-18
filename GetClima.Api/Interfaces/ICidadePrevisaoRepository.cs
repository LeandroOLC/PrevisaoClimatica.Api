using PrevisaoClimatica.Api.Models;

namespace PrevisaoClimatica.Api.Interfaces
{
    public interface ICidadePrevisaoRepository
    {
        void Adicionar(CidadePrevisao cidadePrevisao);
    }
}