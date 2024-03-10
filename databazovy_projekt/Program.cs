using System;
using System.Data.SqlClient;

namespace databazovy_projekt
{

    class SelectStatement
    {

        static void Main()
        {
            Stuff();
            Console.ReadKey();
        }

        static void Stuff()
        {
            Invoker i = new Invoker();
            string Input;
            while (true) {
                Input = Console.ReadLine();
                if (Input == "exit")
                {
                    break;
                }
                if (i.execute(Input) == false)
                {
                    Console.WriteLine("unknown command");
                }
                
            }
            DatabaseSingleton.Close();


        }
    }
}
