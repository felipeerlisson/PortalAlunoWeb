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
    public class ClienteService : IClienteService
    {
        protected readonly IClienteRepository _clienteRepository;

        public ReturnObject retornoStatus = new ReturnObject();

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ReturnObject> AtualizarCliente(Cliente cliente)
        {
           return await _clienteRepository.AtualizarCliente(cliente);
        }

        public async Task<Cliente> BuscarClientePorID(int id)
        {
            return await _clienteRepository.BuscarClientePorID(id);
        }

        public async Task<List<Cliente>> BuscarTodosClientes()
        {
            return await _clienteRepository.BuscarTodosClientes();
        }

        public void ExcluirCliente(int IdCliente)
        {
            _clienteRepository.ExcluirCliente(IdCliente);
        }

        public async Task<ReturnObject> SalvarCliente(Cliente cliente)
        {
            ReturnObject returnObject = new ReturnObject();
            try { 
                _clienteRepository.SalvarCliente(cliente);
                returnObject.Mensagem="Cliente Cadastrado com sucesso";
                returnObject.Sucesso = true;
                return returnObject;
            }
            catch {

                returnObject.Mensagem = "Falha ao cadastrar Cliente";
                returnObject.Sucesso = false;
                return returnObject;

            }
        }
    }
}
