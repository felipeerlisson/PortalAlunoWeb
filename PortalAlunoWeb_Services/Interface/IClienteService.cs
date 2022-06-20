using PortalAlunoWeb_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_Services.Interface
{
     public interface IClienteService
    {
        public Task<List<Cliente>> BuscarTodosClientes();
        Task<Cliente> BuscarClientePorID(int id);
        void SalvarCliente(Cliente cliente);
        Task<ReturnObject> AtualizarCliente(Cliente cliente);
        void ExcluirCliente(int IdCliente);
    }
}
