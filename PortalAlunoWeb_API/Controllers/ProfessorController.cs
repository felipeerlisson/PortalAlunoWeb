using Microsoft.AspNetCore.Mvc;
using PortalAlunoWeb_Domain;
using PortalAlunoWeb_Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalAlunoWeb_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        protected readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService) 
        {
            _professorService = professorService;
        }

        // GET: api/<ProfessorController>
        [HttpGet]
        public async Task<List<Professor>> Get()
        {
            return await _professorService.BuscarTodosProfessor();
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
