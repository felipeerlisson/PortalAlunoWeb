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
        public async Task<Professor> Get(int id)
        {
            Professor professor = new Professor();
            professor=await _professorService.BuscarProfessorPorId(id);
            return professor;
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public void Post([FromBody] Professor professor)
        {
            _professorService.SalvarProfessor(professor);
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Professor professor)
        {
            _professorService.atualizarProfessor(professor);
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _professorService.excluirProfessor(id);
        }
    }
}
