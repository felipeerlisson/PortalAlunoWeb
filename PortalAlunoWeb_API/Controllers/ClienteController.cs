using Microsoft.AspNetCore.Mvc;
using PortalAlunoWeb_Domain;
using PortalAlunoWeb_Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalAlunoWeb_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController: ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteservice)
        { 
            _clienteService = clienteservice; 
        }


        [HttpGet]
        public async Task<List<Cliente>> Get()
        {
            return await _clienteService.BuscarTodosClientes();
        }

        [HttpGet("{id}")]
        public async Task<Cliente> Get(int id) 
        { 
            return await _clienteService.BuscarClientePorID(id); 
        }

        [HttpPost]
        public async Task<ReturnObject> Post(Cliente cliente) 
        {
            return await _clienteService.SalvarCliente(cliente);
        }

        // PUT api/<ProdutoController>/5
        [HttpPut]
        public async Task<ReturnObject> Put([FromBody] Cliente cliente)
        {
            return await _clienteService.AtualizarCliente(cliente);
        }
    }
}
