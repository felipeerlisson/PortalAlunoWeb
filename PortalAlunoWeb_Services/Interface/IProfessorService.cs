using PortalAlunoWeb_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_Services.Interface
{
    public interface IProfessorService
    {
        public Task<List<Professor>> BuscarTodosProfessor();

        public Task<Professor> BuscarProfessorPorId(int Id);

        void SalvarProfessor(Professor professor);

        void atualizarProfessor(Professor professor);

        void excluirProfessor(int COD_PROFESSOR);
    }
}
