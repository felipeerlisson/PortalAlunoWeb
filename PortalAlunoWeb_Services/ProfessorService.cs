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
    public class ProfessorService : IProfessorService
    {
        protected readonly IProfessorRepository _professorRepository;
        public ProfessorService(IProfessorRepository professorRepository)
          {
            _professorRepository=professorRepository;

        }
        public async Task<List<Professor>> BuscarTodosProfessor()
        {
            return await _professorRepository.BuscarTodosProfessor();
        }
    }
}
