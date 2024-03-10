using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    internal class TypPolozky : ITableClass
    {
        public int Id { get; set; }

        public string Jmeno { get; set; }
        public string Prodejce {  get; set; }
        public float Cena { get; set; }

        public override string ToString()
        {
            return "id:" + this.Id + " Jmeno:" + this.Jmeno + " Prodejce:" + this.Prodejce + " Cena:" + this.Cena;
        }

        public TypPolozky(int id,string j,string p,float c)
        {
            this.Id = id;
            this.Jmeno = j;
            this.Prodejce = p;
            this.Cena = c;
        }

        public TypPolozky( string j, string p, float c)
        {
            this.Jmeno = j;
            this.Prodejce = p;
            this.Cena = c;
        }

        public TypPolozky(string j)
        {
            this.Jmeno = j;
        }

        public TypPolozky()
        {
        }
    }
}
