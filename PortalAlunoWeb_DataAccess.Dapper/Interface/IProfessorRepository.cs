using PortalAlunoWeb_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_DataAccess.Dapper.Interface
{
    public interface IProfessorRepository
    {
        public Task<List<Professor>> BuscarTodosProfessor();
    }
}
