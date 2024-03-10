using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    internal class Invoker
    {
        string[] parts;
        //vraci true jestli se povedla a false jestli se nepovedlo
        public bool execute(string com)
        {
            parts = com.Split(" ");
            ITableClass value = null;

            switch (parts[0])
            {
                case "add":
                    CommandAdd ca = new CommandAdd();
                    value = create(parts[1]);
                    ca.Execute(value);
                    return true;
                    break;

                case "delete":
                    Console.WriteLine("enter info about the item you want to remove");
                    CommandDelete de = new CommandDelete();
                    value = create(parts[1]);
                    de.Execute(value);
                    return true;
                    break;

                case "get":
                    CommandGet ge = new CommandGet();
                    int cislo;
                    while (true)
                    {
                        Console.WriteLine("enter id:");
                        try
                        {
                            cislo = Convert.ToInt32(Console.ReadLine());
                            break;
                        } catch (Exception e)
                        {

                        }
                    }
                    ge.Execute(createId(cislo));
                    return true;
                    break;

                case "getall":
                    CommandGetAll ga = new CommandGetAll();
                    ga.Execute(parts[1]);
                    return true;
                    break;

                case "update":
                    CommandChangeDelivered ch = new CommandChangeDelivered();
                    int cislo1 = 0;
                    {
                        while(true) { 
                        Console.WriteLine("enter id:");
                        try
                        {
                            cislo1 = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch (Exception e)
                        {

                        }
                        }
                    }

                    ch.Execute(cislo1);
                    Console.WriteLine("order has been updated");
                    return true;
                    break;

                case "import":
                    CommandImport i = new CommandImport();
                    string file = "";
                    while (true)
                    {
                        Console.WriteLine("enter filename:");
                        try
                        {
                            file = Console.ReadLine();
                            break;
                        }
                        catch (Exception e)
                        {

                        }
                    }
                    try
                    {
                        i.Execute(file);
                    } catch (FileNotFoundException e)
                    {
                        Console.WriteLine("couldn't find file");
                        return false;
                    }
                    return true;
                    break;

                default:
                    return false;
                    break;
            }
            return false;
        }




        /// pouziva se pri pridani dalsi instance do tabulky
        private ITableClass create(string type)
        {
            string jmeno;
            string prijmeni;
            string mesto;
            string ulice;
            string cislo;
            string prodejce;
            string cena;

            switch (type)
            {

                case "zakaznik":
                    while (true)
                    {
                        System.Console.WriteLine("enter first name:");
                        jmeno = Console.ReadLine();

                        System.Console.WriteLine("enter last name:");
                        prijmeni = Console.ReadLine();

                        System.Console.WriteLine("enter city(not mandatory while deleting or getting):");
                        mesto = Console.ReadLine();

                        System.Console.WriteLine("enter street name(not mandatory while deleting or getting):");
                        ulice = Console.ReadLine();

                        System.Console.WriteLine("enter street number(not mandatory while deleting or getting):");
                        cislo = Console.ReadLine();

                        try
                        {
                            Zakaznik z = new Zakaznik(jmeno, prijmeni, mesto, ulice, Convert.ToInt32(cislo));
                            return z;
                        } catch (Exception ex)
                        {
                            System.Console.WriteLine("one or more inputs were wrong please try again:");
                        }
                    }
                    break;

                case "prodejce":
                    while (true)
                    {
                        System.Console.WriteLine("name of suplier:");
                        jmeno = Console.ReadLine();

                        System.Console.WriteLine("enter city(not mandatory while deleting or getting):");
                        mesto = Console.ReadLine();

                        System.Console.WriteLine("enter street name(not mandatory while deleting or getting):");
                        ulice = Console.ReadLine();

                        System.Console.WriteLine("enter street number(not mandatory while deleting or getting):");
                        cislo = Console.ReadLine();

                        try
                        {
                            Prodejce p = new Prodejce(jmeno,mesto,ulice,Convert.ToInt32(cislo));
                            return p;
                        }
                        catch (Exception ex)
                        {
                            System.Console.WriteLine("one or more inputs were wrong please try again:");
                        }
                    }
                    break;

                case "polozky":
                    while (true)
                    {
                        System.Console.WriteLine("name of product:");
                        jmeno = Console.ReadLine();

                        System.Console.WriteLine("enter suplier name(not mandatory while deleting or getting):");
                        prodejce = Console.ReadLine();

                        System.Console.WriteLine("enter price(not mandatory while deleting or getting):");
                        cena = Console.ReadLine();

                        try
                        {
                            TypPolozky p = new TypPolozky(jmeno,prodejce,Convert.ToInt32(cena));
                            return p;
                        }
                        catch (Exception ex)
                        {
                            System.Console.WriteLine("one or more inputs were wrong please try again:");
                        }
                    }
                    break;

                case "objednavka":
                    while (true)
                    {
                        if (this.parts[0] != "delete")
                        {
                            System.Console.WriteLine("full name of customer(first + last name):");
                            jmeno = Console.ReadLine();

                            try
                            {
                                Objednavka o = new Objednavka(jmeno);

                                while (true)
                                {
                                    System.Console.WriteLine("enter name of product (enter done to stop adding products):");
                                    jmeno = Console.ReadLine();
                                    if (jmeno == "done")
                                    {
                                        break;
                                    }
                                    System.Console.WriteLine("ammount:");
                                    cislo = Console.ReadLine();

                                    try
                                    {
                                        o.AddPolozka(new Polozka(jmeno, Convert.ToInt32(cislo)));
                                    }
                                    catch (Exception ex)
                                    {
                                        System.Console.WriteLine("one or more inputs were wrong please try again:");
                                    }

                                }

                                return o;
                            }
                            catch (Exception ex)
                            {
                                System.Console.WriteLine("one or more inputs were wrong please try again:");
                            }
                        } 
                        else
                        {
                            System.Console.WriteLine("id of the order:");
                            cislo = Console.ReadLine();
                            try {
                            Objednavka o = new Objednavka(Convert.ToInt32(cislo));
                                return o;
                            }
                            catch (Exception ex)
                            {
                                System.Console.WriteLine("one or more inputs were wrong please try again:");
                            }
                        }
                    }
                    break;
            }
            return null;
        }

        private ITableClass createId(int id)
        {
            ITableClass output = null;
            switch (this.parts[1])
            {
                case "zakaznik":
                    output = new Zakaznik();
                    break;

                case "prodejce":
                    output = new Prodejce();
                    break;

                case "polozky":
                    output = new TypPolozky();
                    break;

                case "objednavka":
                    output = new Objednavka();
                    break;
            }
            output.Id = id;
            return output;
        }
    }

    }

