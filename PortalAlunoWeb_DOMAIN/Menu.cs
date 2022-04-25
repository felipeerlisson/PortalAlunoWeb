using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_Domain
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
