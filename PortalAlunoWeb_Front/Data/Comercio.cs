namespace PortalAlunoWeb_Front.Data
{
    public class Comercio
    { 
        public int COD_COMERCIO { get; set; }

        public string NOME_COMERCIO { get; set; } = "";

        public Endereco Endereco { get; set; } = new Endereco();
    }
}
