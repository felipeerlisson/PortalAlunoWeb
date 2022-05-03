using PortalAlunoWeb_Domain;

namespace PortalAlunoWeb_Services.Interface
{
    public class IComercioServiceBase
    {
        public Task<List<Comercio>> BuscarTodosComercios();
    }
}