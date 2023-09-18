using Dapper;
using Microsoft.EntityFrameworkCore;
using PrevisaoClimatica.Api.Interfaces;
using PrevisaoClimatica.Api.Models;
using System.Data;
using System.Data.Common;

namespace PrevisaoClimatica.Api.Data.Repository
{
    public class LogsRepository : ILogsRepository
    {
        private readonly PrevisaoClimaticaContext _context;

        public DbConnection ObterConexao() => _context.Database.GetDbConnection();

        public LogsRepository(PrevisaoClimaticaContext context)
        {
            _context = context;
        }

        public void Adicionar(Logs logs)
        {
            string sql = @" INSERT INTO [dbo].[Logs]
                               ([Id]
                               ,[Mensagem]
                               ,[Data])
                         VALUES
                               (@Id
                               ,@Mensagem
                               ,@Data)";

            var parameter = new DynamicParameters();

            parameter.Add("@Id", logs.Id, DbType.Guid, ParameterDirection.Input);
            parameter.Add("@Mensagem", logs.Mensagem, DbType.String, ParameterDirection.Input);
            parameter.Add("@Data", logs.Data, DbType.DateTime, ParameterDirection.Input);

            ObterConexao().ExecuteAsync(sql, parameter);
        }
    }
}
