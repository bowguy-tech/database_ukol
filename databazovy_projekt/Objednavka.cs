using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    internal class Objednavka : ITableClass
    {
        public int Id { get; set; }
        public string ZakCeleJmeno { get; set; }
        public IDictionary<string, float> Polozky { get; set; } = new Dictionary<string, float>();
        public bool Dorucena { get; set; }

        public void AddPolozka(Polozka p)
        {
            if (Polozky == null)
            {
                Polozky = new Dictionary<string, float>();
            }
            if (Polozky.ContainsKey(p.Produkt))
            {
                Polozky[p.Produkt] += p.Pocet;
            } else
            {
                Polozky.Add(new KeyValuePair<string, float>(p.Produkt, p.Pocet));
            }
        }

        public List<Polozka> GetPolozky()
        {
            List<Polozka> Output = new List<Polozka>();

            foreach (var kvp in this.Polozky)
                Output.Add(new Polozka(kvp.Key, kvp.Value));

            return Output;
        }

        public override string ToString()
        {
            string output = "id:" + this.Id + " pro:" + this.ZakCeleJmeno + " dorucena:" + this.Dorucena;

            foreach (var kvp in this.Polozky)
            {
                output += "\n\t" + kvp.Value + " " + kvp.Key;
            }

            return output;
        }

        public Objednavka(int i, string z, bool d)
        {
            this.Id = i;
            this.ZakCeleJmeno = z;
            this.Dorucena = d;

        }

        public Objednavka(string z, bool d)
        {
            this.ZakCeleJmeno = z;
            this.Dorucena = d;

        }

        public Objednavka(string z)
        { 
            this.ZakCeleJmeno = z;
            this.Dorucena = false;
        }

        public Objednavka(int i)
        {
            this.Id = i;

        }
        public Objednavka()
        {
        }


    }
}
