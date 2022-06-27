using Microsoft.AspNetCore.Mvc;
using PortalAlunoWeb_Domain;
using PortalAlunoWeb_Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalAlunoWeb_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        protected readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<List<Cliente>> Get()
        {
            return await _clienteService.BuscarTodosClientes();
        }
        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<Cliente> Get(int id)
        {
            return await _clienteService.BuscarClientePorID(id);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ReturnObject> Post([FromBody] Cliente cliente)
        {
            return await _clienteService.SalvarCliente(cliente);
        }
        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<ReturnObject> Put([FromBody] Cliente cliente)
        {
            return await _clienteService.AtualizarCliente(cliente);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _clienteService.ExcluirCliente(id);
        }
    }
}