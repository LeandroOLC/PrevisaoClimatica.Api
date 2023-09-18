
using Dapper;
using Microsoft.EntityFrameworkCore;
using PrevisaoClimatica.Api.Interfaces;
using PrevisaoClimatica.Api.Models;
using System.Data;
using System.Data.Common;

namespace PrevisaoClimatica.Api.Data.Repository
{
    public class CidadePrevisaoRepository : ICidadePrevisaoRepository
    {
        private readonly PrevisaoClimaticaContext _context;

        public DbConnection ObterConexao() => _context.Database.GetDbConnection();

        public CidadePrevisaoRepository(PrevisaoClimaticaContext context)
        {
            _context = context;
        }

        public void Adicionar(CidadePrevisao cidadePrevisao)
        {
            string sql = @" INSERT INTO [dbo].[CidadePrevisao]
                                ([Id]
                                ,[Cidade]
                                ,[Estado]
                                ,[UltimaAtualizacao]
                                ,[Data]
                                ,[Condicao]
                                ,[Min]
                                ,[Max]
                                ,[IndiceUV]
                                ,[DescricaoClima])
                            VALUES
                                (@Id
                                ,@Cidade
                                ,@Estado
                                ,@UltimaAtualizacao
                                ,@Data
                                ,@Condicao
                                ,@Min
                                ,@Max
                                ,@IndiceUV
                                ,@DescricaoClima)";

            var parameter = new DynamicParameters();

            parameter.Add("@Id", cidadePrevisao.Id, DbType.Guid, ParameterDirection.Input);
            parameter.Add("@Cidade", cidadePrevisao.Cidade, DbType.String, ParameterDirection.Input);
            parameter.Add("@Estado", cidadePrevisao.Estado, DbType.String, ParameterDirection.Input);
            parameter.Add("@UltimaAtualizacao", cidadePrevisao.UltimaAtualizacao, DbType.DateTime, ParameterDirection.Input);
            parameter.Add("@Data", cidadePrevisao.Data, DbType.DateTime, ParameterDirection.Input);
            parameter.Add("@Condicao", cidadePrevisao.Condicao, DbType.String, ParameterDirection.Input);
            parameter.Add("@Min", cidadePrevisao.Min, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Max", cidadePrevisao.Max, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@IndiceUV", cidadePrevisao.IndiceUV, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@DescricaoClima", cidadePrevisao.DescricaoClima, DbType.String, ParameterDirection.Input);

            ObterConexao().ExecuteAsync(sql, parameter);
        }
    }
}
