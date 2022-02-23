using Dapper;
using Microsoft.Extensions.Configuration;
using PortalAlunoWeb_DataAccess.Dapper.Interface;
using PortalAlunoWeb_Domain;
using System.Data;
using System.Data.SqlClient;

namespace PortalAlunoWeb_DataAccess.Dapper
{
    public class AlunoRepository : IAlunoRepository
    {
        //CONFIGURAÇÃO PADRAO DE ABRIR E FECHAR CONEXÃO COM O BANCO DE DADOS (TER EM TODAS AS CLASSES)
        protected readonly IConfiguration _config;

        public AlunoRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DevelopersDbConnection"));
            }
        }

        public async Task<List<Aluno>> BuscarTodosAluno()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();

                    string query = @"SELECT * FROM ALUNO";

                    return (List<Aluno>)await dbConnection.QueryAsync<Aluno>(query);
                }
                    
 
            }
            catch
            {
                throw;
            }
      
        }

        public void ExcluirAluno(int ID_Aluno)
        {
            throw new NotImplementedException();
        }
    }
}
