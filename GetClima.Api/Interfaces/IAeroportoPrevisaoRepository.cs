using PrevisaoClimatica.Api.Models;
using System.Data.Common;

namespace PrevisaoClimatica.Api.Interfaces
{
    public interface IAeroportoPrevisaoRepository
    {
        DbConnection ObterConexao();
        void Adicionar(AeroportoPrevisao aeroportoPrevisao);
    }
}
