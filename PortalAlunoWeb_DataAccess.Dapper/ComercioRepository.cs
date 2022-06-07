using PortalAlunoWeb_Domain;
using PortalAlunoWeb_DataAccess.Dapper.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace PortalAlunoWeb_DataAccess.Dapper
{
    public class ComercioRepository : IComercioRepository
    {
        //CONFIGURAÇÃO PADRAO DE ABRIR E FECHAR CONEXÃO COM O BANCO DE DADOS (TER EM TODAS AS CLASSES)
        protected readonly IConfiguration _config;

        public ComercioRepository(IConfiguration config)
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

        public void AtualizarComercio(Comercio cliente)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comercio>> BuscarComercioPorID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comercio>> BuscarComercioPorNome(string NOME_COMERCIO)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string Query = @"SELECT * FROM COMERCIO WHERE NOME_COMERCIO = @NOME_COMERCIO";
                    dbConnection.Close();
                    return (List<Comercio>)await dbConnection.QueryAsync<Comercio>(Query,new { NOME_COMERCIO=NOME_COMERCIO });
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Comercio>> BuscarTodosComercios()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string Query = @"SELECT * FROM COMERCIO";
                    dbConnection.Close();
                    return (List<Comercio>)await dbConnection.QueryAsync<Comercio>(Query);
                }
            }
            catch
            {
                throw;
            }
        }

        public void ExcluirComercio(int IdComercio)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE COMERCIO WHERE COD_COMERCIO=@IdComercio";
                    dbConnection.Close();
                    dbConnection.Execute(query, new { COD_COMERCIO = @IdComercio });
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ReturnObject> SalvarComercio(Comercio comercio)
        {
          ReturnObject returnObject = new ReturnObject();   


            try
            {

                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @$"insert into COMERCIO (NOME_COMERCIO, CEP, LOGRADOURO, NUMERO,  BAIRRO, LOCALIDADE, UF)
                    VALUES ('{comercio.NOME_COMERCIO}', '{comercio.Endereco.cep}', '{comercio.Endereco.logradouro}', {comercio.Endereco.numero}, '{comercio.Endereco.bairro}', '{comercio.Endereco.localidade}', '{comercio.Endereco.uf}')";
                    dbConnection.Close();
                    dbConnection.Execute(query);

                    returnObject.Sucesso = true;
                    return  returnObject;
                }
            }
            catch(Exception ex)
            {
                  return  returnObject;
            }
        }
    }
}
