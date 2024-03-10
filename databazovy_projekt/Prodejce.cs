using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    internal class Prodejce : ITableClass
    {
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string AdressCity { get; set; }
        public string AdressStreet { get; set; }
        public int AdressNum { get; set; }

        public override string ToString()
        {
            return "id:" + this.Id + " Jmeno:" + this.Jmeno + " mesto:" + this.AdressCity + " ulice:" + this.AdressStreet + " cislo:" + this.AdressNum;
        }

        public Prodejce(int id,string j, string aC, string aS, int aN)
        {
            this.Id = id;
            this.Jmeno = j;
            this.AdressCity = aC;
            this.AdressStreet = aS;
            this.AdressNum = aN;
        }

        public Prodejce(string j, string aC, string aS, int aN)
        {
            this.Jmeno = j;
            this.AdressCity = aC;
            this.AdressStreet = aS;
            this.AdressNum = aN;
        }

        public Prodejce(string j, string aC, int aN)
        {
            this.Jmeno = j;
            this.AdressCity = aC;
            this.AdressNum = aN;
        }

        public Prodejce(string j)
        {
            this.Jmeno = j;
        }
        public Prodejce()
        {

        }


    }
}
