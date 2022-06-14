using PortalAlunoWeb_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_DataAccess.Dapper.Interface
{
    public interface IClienteRepository
    {
        public Task<List<Cliente>> BuscarTodosClientes();
        public Task<Cliente> BuscarClientePorID(int id);
        public void SalvarCliente(Cliente cliente);
        void AtualizarCliente(Cliente cliente);
        void ExcluirCliente(int IdCliente);
    }
}
