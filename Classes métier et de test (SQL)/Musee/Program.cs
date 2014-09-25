using System;
using System.Collections.Generic;

using METIER;
using TECHNIQUE;

namespace TEST
{
    //---------------
    // Classe de TEST
    //---------------
    class Program
    {
        static void Main(string[] args)
        {
            ODBC bd = new ODBC("datmusee");

            Console.WriteLine(bd.GetMusee().AfficherMusee());


            Console.ReadKey();
        }
    }
}
