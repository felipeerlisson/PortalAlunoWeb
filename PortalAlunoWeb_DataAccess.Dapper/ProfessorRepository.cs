using Dapper;
using Microsoft.Extensions.Configuration;
using PortalAlunoWeb_DataAccess.Dapper.Interface;
using PortalAlunoWeb_Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_DataAccess.Dapper
{
    public class ProfessorRepository : IProfessorRepository

    {
        //CONFIGURAÇÃO PADRAO DE ABRIR E FECHAR CONEXÃO COM O BANCO DE DADOS (TER EM TODAS AS CLASSES)
        protected readonly IConfiguration _config;

        public ProfessorRepository(IConfiguration config)
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

        public void atualizarProfessor(Professor professor)
        {
            try
            {
                using(IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE PROFESSOR SET NOME_PROFESSOR = @NOME_PROFESSOR,IDADE_PROFESSOR=@IDADE_PROFESSOR WHERE COD_PROFESSOR=@COD_PROFESSOR";
                    dbConnection.Execute(query, professor);
                    dbConnection.Close();
                }
            }
            catch 
            { 
                throw; 
            }
        }

        public async Task<Professor> BuscarProfessorPorId(int Id)
        {
            try 
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM PROFESSOR WHERE COD_PROFESSOR = @id";

                    dbConnection.Open();
                    return await dbConnection.QueryFirstAsync<Professor>(query, new { Id = @Id });
                }
            }
            catch 
            { 
                throw; 
            }
        }
        public async Task<List<Professor>> BuscarTodosProfessor()
        {
            try
            {
                using (IDbConnection dbConnection=Connection)
                {
                    dbConnection.Open();
                    string Query= @"SELECT * FROM PROFESSOR";
                    dbConnection.Close();
                    return (List<Professor>)await dbConnection.QueryAsync<Professor>(Query);
                    

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void excluirProfessor(int COD_PROFESSOR)
        {
            try
            {
                using(IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE PROFESSOR WHERE COD_PROFESSOR=@COD_PROFESSOR";
                    dbConnection.Close();
                    dbConnection.Execute(query, new { COD_PROFESSOR = @COD_PROFESSOR });
                }
            }
            catch
            {
                throw;
            }
        }

        public void salvarProfessor(Professor professor)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO PROFESSOR(NOME_PROFESSOR, IDADE_PROFESSOR) VALUES(@NOME_PROFESSOR, @IDADE_PROFESSOR)";
                    dbConnection.Close();
                    dbConnection.Execute(query, professor);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}