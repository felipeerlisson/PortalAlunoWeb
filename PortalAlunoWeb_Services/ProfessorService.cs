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

        public void AtualizarProfessor(Professor professor)
        {
            _professorRepository.atualizarProfessor(professor);
        }

        public void atualizarProfessor(Professor professor)
        {
            throw new NotImplementedException();
        }

        public async Task<Professor> BuscarProfessorPorId(int Id)
        {
            return await _professorRepository.BuscarProfessorPorId(Id);
        }

        public async Task<List<Professor>> BuscarTodosProfessor()
        {
            return await _professorRepository.BuscarTodosProfessor();
        }

        public void excluirProfessor(int COD_PROFESSOR)
        {
            _professorRepository.excluirProfessor(COD_PROFESSOR);
        }

        public void SalvarProfessor(Professor professor)
        {
             _professorRepository.salvarProfessor(professor);
        }
    }
}
