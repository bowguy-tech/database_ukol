using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    internal class CommandDelete : Command
    {
        public override void Execute(ITableClass Instance)
        {
            switch (Instance.GetType().Name)
            {
                case "Zakaznik":
                    TableZakaznik t = new TableZakaznik();
                    t.Delete((Zakaznik)Instance);
                    break;

                case "Prodejce":
                    TableProdejce p = new TableProdejce();
                    p.Delete((Prodejce)Instance);
                    break;

                case "TypPolozky":
                    TablePolozka po = new TablePolozka();
                    po.Delete((TypPolozky)Instance);
                    break;

                case "Objednavka":
                    TableObjednavka o = new TableObjednavka();
                    o.Delete((Objednavka)Instance);
                    break;


            }
        }
    }
}
