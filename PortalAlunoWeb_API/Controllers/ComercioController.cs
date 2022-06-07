using Microsoft.AspNetCore.Mvc;
using PortalAlunoWeb_Domain;
using PortalAlunoWeb_Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalAlunoWeb_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercioController : ControllerBase
    {
        protected readonly IComercioService _comercioService;

        public ComercioController(IComercioService comercioService)
        {
            _comercioService = comercioService;
        }


        // GET: api/<ComercioController>
        [HttpGet]
        public async Task<List<Comercio>> Get()
        {
            return await _comercioService.BuscarTodosComercios();
        }

        // GET api/<ComercioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ComercioController>
        [HttpPost]
        public async Task<ReturnObject> Post([FromBody] Comercio comercio)
        {

            return await  _comercioService.SalvarComercio(comercio);
        }

        // PUT api/<ComercioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ComercioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
