using Microsoft.AspNetCore.Mvc;
using PortalAlunoWeb_Domain;
using PortalAlunoWeb_Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalAlunoWeb_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        protected readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public async Task<List<Aluno>> Get()
        {
            List<Aluno> ListaAlunos = new List<Aluno>();

            ListaAlunos = await _alunoService.BuscarTodosAlunos();

            return ListaAlunos;
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlunoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
