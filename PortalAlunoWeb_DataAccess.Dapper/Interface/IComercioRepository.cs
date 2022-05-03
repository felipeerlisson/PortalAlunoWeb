using PortalAlunoWeb_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_DataAccess.Dapper.Interface
{
    public interface IComercioRepository
    {
        public Task<List<Comercio>> BuscarTodosComercios();
        public Task<ReturnObject> SalvarComercio(Comercio comercio);

    }
}