namespace PortalAlunoWeb_Front.Data
{
    public class Cliente
    {
        public int COD_CLIENTE { get; set; }
        public string NOME_CLIENTE { get; set; } = "";
        public string EMAIL_CLIENTE { get; set; }
        public string CEP { get; set; } = "";
        public string LOGRADOURO { get; set; } = "";
        public string NUMERO { get; set; } = "";
        public string BAIRRO { get; set; } = "";
        public string LOCALIDADE { get; set; } = "";
        public string UF { get; set; } = "";
        public Endereco Endereco { get; set; } = new Endereco();
    }
}