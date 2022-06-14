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

        public ClienteController(IClienteService clienteservice) { _clienteService = clienteservice; }
        
        [HttpPost]

        public async Task<ReturnObject> Post(Cliente cliente) 
        {
            return await _clienteService.SalvarCliente(cliente);
        }
    }
}
