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

        public ClienteRepository(IConfiguration config)
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

        public async Task<ReturnObject> AtualizarCliente(Cliente cliente)
        {
            ReturnObject retorno = new ReturnObject();

            try
            {

                using (IDbConnection dbConnection = Connection)
                { 
                    dbConnection.Open();
                    string Query = @$"UPDATE CLIENTE SET NOME_CLIENTE='{cliente.NOME_CLIENTE}', EMAIL_CLIENTE='{cliente.EMAIL_CLIENTE}', CEP='{cliente.Endereco.cep}', LOGRADOURO='{cliente.Endereco.logradouro}', NUMERO='{cliente.Endereco.numero}',  BAIRRO='{cliente.Endereco.bairro}', LOCALIDADE='{cliente.Endereco.localidade}', UF='{cliente.Endereco.uf}' WHERE COD_CLIENTE='{cliente.COD_CLIENTE}'";
                    dbConnection.Close();
                    dbConnection.Execute(Query , cliente);
                }
                retorno.Mensagem = "Cliente atualizado com sucesso!";
                retorno.Sucesso = true;
                return retorno;
            }
            catch
            {
                retorno.Mensagem = "Cliente não atualizado!";
                retorno.Sucesso = false;
                return retorno;
            }
        }

        public async Task<Cliente> BuscarClientePorID(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string Query = "SELECT * FROM CLIENTE WHERE COD_CLIENTE = @id";
                    dbConnection.Close();
                    return await dbConnection.QueryFirstAsync<Cliente>(Query,new { id = @id });
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
                    string Query = "SELECT * FROM CLIENTE WHERE DATA_EXCLUSAO IS NULL";
                    dbConnection.Close();
                    return (List<Cliente>)await dbConnection.QueryAsync<Cliente>(Query);
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
                    string Query = "UPDATE CLIENTE SET DATA_EXCLUSAO= GETDATE() WHERE COD_CLIENTE=@IdCliente";
                    dbConnection.Close();
                    dbConnection.Execute(Query, new { IdCliente = @IdCliente });
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ReturnObject> SalvarCliente(Cliente cliente)
        {
            ReturnObject returnObject = new ReturnObject();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @$"INSERT INTO CLIENTE(NOME_CLIENTE, EMAIL_CLIENTE, CEP, LOGRADOURO, NUMERO,  BAIRRO, LOCALIDADE, UF) 
                     VALUES('{cliente.NOME_CLIENTE}', '{cliente.EMAIL_CLIENTE}','{cliente.Endereco.cep}', '{cliente.Endereco.logradouro}', '{cliente.Endereco.numero}', '{cliente.Endereco.bairro}','{cliente.Endereco.localidade}', '{cliente.Endereco.uf}')";
                    dbConnection.Close();
                    dbConnection.Execute(query); 

                    returnObject.Sucesso = true;
                    return returnObject;
                }
            }
            catch
            {
                return returnObject;
            }
        }
    }
}