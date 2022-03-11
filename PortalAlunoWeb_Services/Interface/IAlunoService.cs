using PortalAlunoWeb_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_Services.Interface
{
    public interface IAlunoService
    {
        Task<List<Aluno>> BuscarTodosAlunos();
        Task<Aluno> BuscarAlunoPorId(int Id);
        void AtualizarAluno(Aluno aluno);
        void SalvarAluno(Aluno aluno);
        void ExcluirAluno(int COD_ALUNO);
    }
}
