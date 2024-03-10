using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace databazovy_projekt
{
    internal class CommandImport
    {
        public void Execute(string filename)
        {
            String URLString = Directory.GetCurrentDirectory() + "\\xml\\" + filename +".xml";
            XmlTextReader reader = new XmlTextReader(URLString);
            List<string> values = new List<string>();
            while (reader.Read())
            {
                try {

                switch (reader.NodeType)
                {

                    case XmlNodeType.Text:
                        values.Add(reader.Value);
                        break;

                    case XmlNodeType.EndElement:
                        switch (reader.Name) {
                            case "zakaznik":
                                TableZakaznik tz = new TableZakaznik();
                                tz.Save(new Zakaznik(values[0], values[1], values[2], values[3], Convert.ToInt32(values[4])));
                                Console.WriteLine("zakaznik saved");
                                values.Clear();
                                break;

                            case "prodejce":
                                TableProdejce tp = new TableProdejce();
                                tp.Save(new Prodejce(values[0], values[1], values[2], Convert.ToInt32(values[3])));
                                Console.WriteLine("prodejce saved");
                                values.Clear();
                                break;

                            case "polozka":
                                TablePolozka tpo = new TablePolozka();
                                tpo.Save(new TypPolozky(values[0], values[1], float.Parse(values[2])));
                                Console.WriteLine("polozka saved");
                                values.Clear();
                                break;

                        }
                        break;
                }

                } 
                catch (Exception e)
                {
                    Console.WriteLine("object skipped due to wrong values");
                }
            }
        }

    }
}
