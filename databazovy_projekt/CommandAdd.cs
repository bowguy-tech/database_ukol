using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    internal class CommandAdd : Command
    {
        public override void Execute(ITableClass Instance)
        {
            switch (Instance.GetType().Name)
            {
                case "Zakaznik":
                    TableZakaznik t = new TableZakaznik();
                    t.Save((Zakaznik)Instance);
                    break;

                case "Prodejce":
                    TableProdejce p = new TableProdejce();
                    p.Save((Prodejce)Instance);
                    break;

                case "TypPolozky":
                    TablePolozka po = new TablePolozka();
                    po.Save((TypPolozky)Instance);
                    break;

                case "Objednavka":
                    TableObjednavka o = new TableObjednavka();
                    o.Save((Objednavka)Instance);
                    break;


            }
        }

    }
}
