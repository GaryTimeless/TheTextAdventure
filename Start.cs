﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace Text.Adv.mit_Greg
{
    public class Start
    {

        public static Player currentPlayer = new Player();
        public static bool mainloop = true;
       
        public static Random rand = new Random();


        static Player NewStart()
        {
            Console.Clear();
            Player p = new Player();
            Console.WriteLine(" Willkomen in Text Adventure ")
                  Console.WriteLine("Wie heißt du Krieger?");
                      currentPlayer.name = Console.ReadLine();
                 Console.ReadKey();
            Console.Clear();
            return p;
        }
       
    }
}
