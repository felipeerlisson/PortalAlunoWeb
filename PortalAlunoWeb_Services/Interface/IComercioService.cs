using PortalAlunoWeb_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_Services.Interface
{
    public interface IComercioService
    {
        public Task<List<Comercio>> BuscarTodosComercios();
        public Task<ReturnObject> SalvarComercio(Comercio comercio);
    }
}