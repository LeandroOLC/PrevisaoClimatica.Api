using Dapper;
using Microsoft.EntityFrameworkCore;
using PrevisaoClimatica.Api.Interfaces;
using PrevisaoClimatica.Api.Models;
using System.Data;
using System.Data.Common;

namespace PrevisaoClimatica.Api.Data.Repository
{
    public class AeroportoPrevisaoRepository : IAeroportoPrevisaoRepository
    {
        private readonly PrevisaoClimaticaContext _context;

        public DbConnection ObterConexao() => _context.Database.GetDbConnection();

        public AeroportoPrevisaoRepository(PrevisaoClimaticaContext context)
        {
            _context = context;
        }

        public void Adicionar(AeroportoPrevisao aeroportoPrevisao)
        {
            string sql = @"INSERT INTO [dbo].[AeroportoPrevisao]
                                ([Id]
                                ,[CodigoIcao]
                                ,[UltimaAtualizacao]
                                ,[PressaoAtmosferica]
                                ,[Visibilidade]
                                ,[Vento]
                                ,[DirecaoVento]
                                ,[Umidade]
                                ,[Condicao]
                                ,[DescricaoClima]
                                ,[Tempo])
                            VALUES
                                (@Id
                                ,@CodigoIcao
                                ,@UltimaAtualizacao
                                ,@PressaoAtmosferica
                                ,@Visibilidade
                                ,@Vento
                                ,@DirecaoVento
                                ,@Umidade
                                ,@Condicao
                                ,@DescricaoClima
                                ,@Tempo)";

            var parameter = new DynamicParameters();

            parameter.Add("@Id", aeroportoPrevisao.Id, DbType.Guid, ParameterDirection.Input);
            parameter.Add("@CodigoIcao", aeroportoPrevisao.CodigoIcao, DbType.String, ParameterDirection.Input);
            parameter.Add("@UltimaAtualizacao", aeroportoPrevisao.UltimaAtualizacao, DbType.DateTime, ParameterDirection.Input);
            parameter.Add("@PressaoAtmosferica", aeroportoPrevisao.PressaoAtmosferica, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Visibilidade", aeroportoPrevisao.Visibilidade, DbType.String, ParameterDirection.Input);
            parameter.Add("@Vento", aeroportoPrevisao.Vento, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@DirecaoVento", aeroportoPrevisao.DirecaoVento, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Umidade", aeroportoPrevisao.Umidade, DbType.String, ParameterDirection.Input);
            parameter.Add("@Condicao", aeroportoPrevisao.Condicao, DbType.String, ParameterDirection.Input);
            parameter.Add("@DescricaoClima", aeroportoPrevisao.DescricaoClima, DbType.String, ParameterDirection.Input);
            parameter.Add("@Tempo", aeroportoPrevisao.Tempo, DbType.Int32, ParameterDirection.Input);

            ObterConexao().ExecuteAsync(sql, parameter);
        }
    }
}
