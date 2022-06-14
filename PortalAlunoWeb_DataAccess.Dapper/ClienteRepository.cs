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
    public class ClienteRepository : IClienteRepository
    {
        //CONFIGURAÇÃO PADRAO DE ABRIR E FECHAR CONEXÃO COM O BANCO DE DADOS (TER EM TODAS AS CLASSES)
        protected readonly IConfiguration _config;
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DevelopersDbConnection"));
            }
        }

        public void AtualizarCliente(Cliente cliente)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string Query = "UPDATE CLIENTE SET NOME_CLIENTE=@NOME_CLIENTE,EMAIL_CLIENTE=@EMAIL_CLIENTE WHERE COD_CLIENTE=@idCliente";
                    dbConnection.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Cliente> BuscarClientePorID(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string Query = "SELECT * FROM CLIENTE where COD_CLIENTE = @id";
                    dbConnection.Close();
                    return (Cliente)await dbConnection.QueryAsync<Cliente>(Query);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Cliente>> BuscarTodosClientes()
        {
            try 
            {
                using (IDbConnection dbConnection = Connection) 
                {
                dbConnection.Open();
                string Query = "SELECT * FROM CLIENTE";
                dbConnection.Close();
                    return (List<Cliente>) await dbConnection.QueryAsync<Cliente>(Query);
                }
            }
            catch 
            { 
                throw; 
            }
        }

        public void ExcluirCliente(int IdCliente)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string Query = "DELETE CLIENTE WHERE COD_CLIENTE=@IdCliente";
                    dbConnection.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        public void SalvarCliente(Cliente cliente)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO CLIENTE(NOME_CLIENTE, EMAIL_CLIENTE) VALUES(@NOME_CLIENTE, @EMAIL_CLIENTE)";
                    dbConnection.Close();
                    dbConnection.Execute(query, cliente);

                }
            }
            catch
            {
                throw;
            }
        }
    }
}
