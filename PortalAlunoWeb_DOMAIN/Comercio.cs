using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_Domain
{
    public class Comercio
    {
        public int COD_COMERCIO { get; set; }
        public string NOME_COMERCIO { get; set; }
        public string CEP { get; set; }
        public string logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }

        public string UF { get; set; }

        public Endereco Endereco { get; set; }


    }
}