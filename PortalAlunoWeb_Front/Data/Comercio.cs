namespace PortalAlunoWeb_Front.Data
{
    public class Comercio
    { 
        public int COD_COMERCIO { get; set; }

        public string NOME_COMERCIO { get; set; } = "";

        public string CEP { get; set; } = "";
        public string logradouro { get; set; } = "";
        public string Numero { get; set; } = "";
        public string Bairro { get; set; } = "";
        public string Localidade { get; set; } = "";

        public string UF { get; set; } = "";

        public Endereco Endereco { get; set; } = new Endereco();
    }
}
