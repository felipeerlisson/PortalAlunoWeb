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
    public class MenuRepository : IMenuRepository
    {
        protected readonly IConfiguration _config;

        public MenuRepository(IConfiguration config)
        {
            _config = config;
        }

        //criando o dbconect
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DevelopersDbConnection"));
            }
        }

        public async Task<IEnumerable<Menu>> BuscarMenu()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM TMENU";
                    return await dbConnection.QueryAsync<Menu>(query);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Menu> BuscarMenuById(int COD_MENU)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM TMENU WHERE COD_MENU = @COD_MENU";
                    return await dbConnection.QueryFirstOrDefaultAsync<Menu>(query, new { COD_MENU = COD_MENU });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Menu_Item>> BuscarSubMenu()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM TMENU_ITEM";
                    return await dbConnection.QueryAsync<Menu_Item>(query);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Menu_Item> BuscarSubMenuById(int COD_MENU_ITEM)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM TMENU_ITEM WHERE COD_MENU_ITEM = @COD_MENU_ITEM";
                    return await dbConnection.QueryFirstOrDefaultAsync<Menu_Item>(query, new { COD_MENU_ITEM = COD_MENU_ITEM });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Menu_Item>> ListaSubMenuByMenuId(int COD_MENU)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM TMENU_ITEM WHERE COD_MENU = @COD_MENU";
                    return await dbConnection.QueryAsync<Menu_Item>(query, new { COD_MENU = COD_MENU });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
