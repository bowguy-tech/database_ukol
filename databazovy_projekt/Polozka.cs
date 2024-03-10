using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    internal class Polozka
    {
        public string Produkt { get; set; }
        public float Pocet { get; set; }

        public Polozka(string pr, float po)
        {
            this.Produkt = pr;
            this.Pocet = po;   
        }

        public override string ToString()
        {
            return "product: " + this.Produkt + " pocet: " + this.Pocet.ToString();
        }
    }
}
