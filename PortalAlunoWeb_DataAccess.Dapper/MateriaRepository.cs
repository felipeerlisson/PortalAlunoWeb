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
    public class MateriaRepository:IMateriaRepository
    {
        //CONFIGURAÇÃO PADRAO DE ABRIR E FECHAR CONEXÃO COM O BANCO DE DADOS (TER EM TODAS AS CLASSES)
        protected readonly IConfiguration _config;

        public MateriaRepository(IConfiguration config)
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

        public async Task<List<Materia>> BuscarTodasMaterias() 
        {
            try
            {
                using (IDbConnection dbConnection = Connection) 
                {
                    dbConnection.Open();
                    string Query = @"SELECT * FROM MATERIA";
                    dbConnection.Close();
                    return (List<Materia>)await dbConnection.QueryAsync<Materia>(Query);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
