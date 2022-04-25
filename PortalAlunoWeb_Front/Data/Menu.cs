namespace PortalAlunoWeb_Front.Data
{
    public class Menu
    {
        public int COD_MENU { get; set; }

        public string DES_MENU { get; set; }

        public int DES_COD_MENU { get; set; }

        public string DES_ICONE { get; set; }

        public List<Menu_Item> ItensMenu { get; set; }


    }
}
