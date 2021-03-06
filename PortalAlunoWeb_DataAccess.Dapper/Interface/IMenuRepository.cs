using PortalAlunoWeb_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_DataAccess.Dapper.Interface
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> BuscarMenu();
        Task<Menu> BuscarMenuById(int Id);
        Task<IEnumerable<Menu_Item>> BuscarSubMenu();
        Task<Menu_Item> BuscarSubMenuById(int Id);
        Task<IEnumerable<Menu_Item>> ListaSubMenuByMenuId(int Id);
    }
}
