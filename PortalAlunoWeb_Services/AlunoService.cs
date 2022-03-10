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
    public class AlunoService : IAlunoService
    {
        protected readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<Aluno> BuscarAlunoPorId(int Id)
        {
            return await _alunoRepository.BuscarAlunoPorId(Id);
        }

        public async Task<List<Aluno>> BuscarTodosAlunos()
        {
            return await _alunoRepository.BuscarTodosAluno();
        }

        public void ExcluirAluno(int COD_ALUNO)
        {
            _alunoRepository.ExcluirAluno(COD_ALUNO);
        }

        public void SalvarAluno(Aluno aluno)
        {
            _alunoRepository.SalvarAluno(aluno);
        }
    }
}
