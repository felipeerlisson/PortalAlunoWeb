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
        protected readonly IComercioRepository _comercioRepository;

        public ReturnObject retornoStatus = new ReturnObject();
        public ComercioService(IComercioRepository comercioRepository)
        {
            _comercioRepository = comercioRepository;
        }

        public Task<List<Comercio>> BuscarTodosComercios()
        {
            throw new NotImplementedException();
        }

        public async Task<ReturnObject> SalvarComercio(Comercio comercio)
        {
            try
            {
                retornoStatus = await _comercioRepository.SalvarComercio(comercio);

                if (retornoStatus.Sucesso)
                {
                    retornoStatus.Mensagem = "Comércio criado com Sucesso!";
                }
                else
                {
                    retornoStatus.Mensagem = "Falha ao criar o comércio!";
                }

                return retornoStatus;  
                
            }
            catch (Exception ex)
            {

                Console.Write(ex);

                retornoStatus.Mensagem = "Falha ao criar o comércio!";

                return retornoStatus;
            }
        }
    }
}
