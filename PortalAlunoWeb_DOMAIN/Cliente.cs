using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_Domain
{
    public class Cliente
    {
        public int COD_CLIENTE { get; set; }
        public string NOME_CLIENTE { get; set; }
        public string EMAIL_CLIENTE { get; set; }
        public DateTime DATA_EXCLUSAO { get; set; }
        public string CEP { get; set; }
        public string logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public Endereco Endereco { get; set; }

    }
}
