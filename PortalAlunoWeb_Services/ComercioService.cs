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

        public async Task<List<Comercio>> BuscarTodosComercios()
        {
            return await _comercioRepository.BuscarTodosComercios();
        }

        public async Task<ReturnObject> SalvarComercio(Comercio comercio)
        {
            ReturnObject returnObject = new ReturnObject();
            returnObject= await ValidarComercio(comercio);
            if (returnObject.Sucesso) 
            {
                _comercioRepository.SalvarComercio(comercio);
                return returnObject;
            }
            else 
            {
                return returnObject;
            }
        }

        public async Task<ReturnObject> ValidarComercio(Comercio comercio)
        {
            ReturnObject retornoStatus= new ReturnObject();
            List<Comercio> listaDeComerciosDuplicados = new List<Comercio>();
            try
            {
                listaDeComerciosDuplicados= await _comercioRepository.BuscarComercioPorNome(comercio.NOME_COMERCIO);
                 if(listaDeComerciosDuplicados.Any()) 
                {
                    retornoStatus.Mensagem = "Falha ao criar comercio, Comercio já existente";
                    retornoStatus.Sucesso = false;
                    return retornoStatus;
                }
                else 
                {
                    retornoStatus.Mensagem = "Comercio criado com sucesso.";
                    retornoStatus.Sucesso = true;
                    return retornoStatus;
                }
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
