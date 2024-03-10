using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    internal class CommandGet : Command
    {
        public override void Execute(ITableClass Instance)
        {
            switch (Instance.GetType().Name)
            {
                case "Zakaznik":
                    TableZakaznik t = new TableZakaznik();
                    Console.WriteLine(t.GetById(((Zakaznik)Instance).Id));
                    break;

                case "Prodejce":
                    TableProdejce p = new TableProdejce();
                    Console.WriteLine(p.GetById(((Prodejce)Instance).Id));
                    break;

                case "TypPolozky":
                    TablePolozka po = new TablePolozka();
                    Console.WriteLine(po.GetById(((TypPolozky)Instance).Id));
                    break;

                case "Objednavka":
                    TableObjednavka o = new TableObjednavka();
                    Console.WriteLine(o.GetById(((Objednavka)Instance).Id));
                    break;


            }
        }
    }
}
