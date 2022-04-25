using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAlunoWeb_Domain
{
    public class Menu_Item
    {
        public int COD_MENU_ITEM { get; set; }

        public Menu objMenu { get; set; }

        public int COD_MENU { get; set; }
        public int COD_MENU_ITEM_PAI { get; set; }

        public string DES_MENU_ITEM { get; set; }

        public string DES_SEQUENCIA_ITEM { get; set; }

        public string DES_LINK { get; set; }

        public string DES_ICONE { get; set; }
    }
}
