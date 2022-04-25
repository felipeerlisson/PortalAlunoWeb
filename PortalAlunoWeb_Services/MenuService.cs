using PortalAlunoWeb_DataAccess.Dapper.Interface;
using PortalAlunoWeb_Domain;
using PortalAlunoWeb_Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_Services
{
    public class MenuService : IMenuService
    {
        protected readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public Task<IEnumerable<Menu>> BuscarMenu()
        {
            return _menuRepository.BuscarMenu();
        }

        public Task<Menu> BuscarMenuById(int Id)
        {
            return _menuRepository.BuscarMenuById(Id);
        }

        public Task<IEnumerable<Menu_Item>> BuscarSubMenu()
        {
            return _menuRepository.BuscarSubMenu();
        }

        public Task<Menu_Item> BuscarSubMenuById(int Id)
        {
            return _menuRepository.BuscarSubMenuById(Id);
        }

        public Task<IEnumerable<Menu_Item>> ListaSubMenuByMenuId(int Id)
        {
            return _menuRepository.ListaSubMenuByMenuId(Id);
        }
    }
}
