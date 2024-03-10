using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    internal class Zakaznik : ITableClass
    {
        public int Id { get; set; }
        public string Jmeno {  get; set; }
        public string Prijmeni { get; set; }
        public string Created { get; set; }
        public string AdressCity { get; set; }
        public string AdressStreet { get; set; }
        public int AdressNum { get; set; }

        public Zakaznik(string j, string p, string aC, string aS, int aN, string c) {
            this.Jmeno = j;
            this.Prijmeni = p;
            this.AdressCity = aC;
            this.AdressStreet = aS;
            this.AdressNum = aN;
            this.Created = c;
        }

        public Zakaznik(string j, string p, string aC, string aS, int aN)
        {
            this.Jmeno = j;
            this.Prijmeni = p;
            this.AdressCity = aC;
            this.AdressStreet = aS;
            this.AdressNum = aN;
        }

        public Zakaznik(string j, string p, string aC, int aN)
        {
            this.Jmeno = j;
            this.Prijmeni = p;
            this.AdressCity = aC;
            this.AdressNum = aN;
        }

        public Zakaznik(string j, string p)
        {
            this.Jmeno = j;
            this.Prijmeni = p;
        }

        public Zakaznik()
        {
        }

        public override string ToString()
        {
            return "jmeno:" + this.Jmeno +
                " prijmeni:" + this.Prijmeni +
                " created:" + this.Created +
                " city:" + this.AdressCity +
                " street:" + this.AdressStreet +
                " number:" + this.AdressNum; 
        }
    }
}
