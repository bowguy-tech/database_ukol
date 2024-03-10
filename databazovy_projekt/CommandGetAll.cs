using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{

    internal class CommandGetAll
    {
        public void Execute(string type)
        {

            switch (type)
            {
                case "zakaznik":
                    TableZakaznik t = new TableZakaznik();
                    Console.Write(t.ToString());
                    break;

                case "prodejce":
                    TableProdejce p = new TableProdejce();
                    Console.Write(p.ToString());
                    break;

                case "polozka":
                    TablePolozka po = new TablePolozka();
                    Console.Write(po.ToString());
                    break;

                case "objednavka":
                    TableObjednavka o = new TableObjednavka();
                    Console.Write(o.ToString());
                    break;
            }
        }
    }
}
