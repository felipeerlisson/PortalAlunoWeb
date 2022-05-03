using PortalAlunoWeb_Domain;
using PortalAlunoWeb_DataAccess.Dapper.Interface;
using PortalAlunoWeb_Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_Services
{
    public class ComercioService : IComercioService
    {

        public Task<List<Comercio>> BuscarTodosComercios()
        {
            throw new NotImplementedException();
        }
    }
}
