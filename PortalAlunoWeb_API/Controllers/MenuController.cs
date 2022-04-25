using Microsoft.AspNetCore.Mvc;
using PortalAlunoWeb_Domain;
using PortalAlunoWeb_Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalAlunoWeb_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        protected readonly IMenuService _menuService;
        List<Menu> _Menus = new List<Menu>();
        List<Menu_Item> _MenuItens = new List<Menu_Item>();

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }


        // GET: api/<MenuController>
        [HttpGet]
        public async Task<IEnumerable<Menu>> GetMenus()
        {
            var menus = await _menuService.BuscarMenu();
            var submenus = await _menuService.BuscarSubMenu();

            _Menus = (menus as IEnumerable<object>).Cast<Menu>().ToList();

            _MenuItens = (submenus as IEnumerable<object>).Cast<Menu_Item>().ToList();

            foreach (var menu in _Menus)
            {
                menu.ItensMenu = _MenuItens;
            }

            return _Menus;
        }


        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MenuController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
