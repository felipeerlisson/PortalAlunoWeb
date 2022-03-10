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

        public async Task<Aluno> BuscarAlunoPorId(int Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();

                    string query = @"SELECT * FROM ALUNO WHERE COD_ALUNO = @Id";

                    dbConnection.Close();
                    return await dbConnection.QueryFirstAsync<Aluno>(query, new { Id = @Id});
                }


            }
            catch
            {
                throw;
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

                    dbConnection.Close();
                    return (List<Aluno>)await dbConnection.QueryAsync<Aluno>(query);
                }
                    
 
            }
            catch
            {
                throw;
            }
      
        }

        public void ExcluirAluno(int COD_ALUNO)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                string query = @"DELETE ALUNO WHERE COD_ALUNO = @COD_ALUNO";

                dbConnection.Close();

                dbConnection.Execute(query, new { COD_ALUNO = @COD_ALUNO });
            }
        }

        public void SalvarAluno(Aluno aluno)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();

                    string query = @"INSERT INTO ALUNO (NOME_ALUNO, IDADE_ALUNO) VALUES (@NOME_ALUNO, @IDADE_ALUNO)";

                    dbConnection.Close();

                    dbConnection.Execute(query,aluno);
                }


            }
            catch
            {
                throw;
            }
        }
    }
}
