using System;
using System.Collections.Generic;
using System.Text;

namespace Text.Adv.mit_Greg
{
    class Shop
    {
        public static void LoadShop(Player p)
        {
            RunShop(p);// Shop wird aufgrufen 
        }

        public static void RunShop(Player p)
        {
            int TrankP;
            int armorP;
            int weaponP;
            int CasinoP;

            while (true)
            {
                TrankP = 10;
                armorP = 100 * p.armorValue;
                weaponP = 100 * (p.weaponValue);
                CasinoP = 100;
                Console.Clear();
                Console.WriteLine(Pics.titel4);//
                Console.WriteLine("<><><><><><><><><><><><><><><><>><><><><><><>><><><><><><>");
                Console.WriteLine("<>============Taverne===================================<>");
                Console.WriteLine("<>|(T)rank:$ " + TrankP);
                Console.WriteLine("<>|                          ");
                Console.WriteLine("<>|(W)affe:$ " + weaponP);
                Console.WriteLine("<>|                         ");
                Console.WriteLine("<>|(R)üstung:$ " + armorP);
                Console.WriteLine("<>|                          ");
                Console.WriteLine("<>|(K)artenspiel:$" + CasinoP);
                Console.WriteLine("<>======================================================<>");
                Console.WriteLine("<><><><><><><><><><><><><><><><>><><><><><><>><><><><><><>");
                Console.WriteLine("<>============================<>");
                Console.WriteLine("<>============================<>");
                Console.WriteLine("<><><><><><><><><><><><><><><><>><><><><><><>><><><><><><>");
                Console.WriteLine("<>===========" + p.name + "=============================<>");
                Console.WriteLine("<>|Münzen " + p.coins);
                Console.WriteLine("<>|                          ");
                Console.WriteLine("<>|Waffenstärke " + p.weaponValue);
                Console.WriteLine("<>|                          ");
                Console.WriteLine("<>|Rüstungstärke: " + p.armorValue);
                Console.WriteLine("<>|                          ");
                Console.WriteLine("<>|Tränke " + p.potion);
                Console.WriteLine("<>======================================================<>");
                Console.WriteLine("<><><><><><><><><><><><><><><><>><><><><><><>><><><><><><>");
                Console.WriteLine("<>(e) for exit shop <>");
            

                string input = Console.ReadLine();

                if (input.ToLower() == "t" || input.ToLower() == "trank")
                {
                    TryBuy("trank", TrankP, p);
                }
                else if (input.ToLower() == "w" || input.ToLower() == "waffe")
                {
                    TryBuy("waffe", weaponP, p);
                }
                else if (input.ToLower() == "r" || input.ToLower() == "rüstung")
                {
                    TryBuy("rüstung", armorP, p);
                }
                else if (input.ToLower() == "k" || input.ToLower() == "kartenspiel")
                {
                    TryBuy("´kartenspiel", CasinoP, p);

                }
                else if (input.ToLower() == "e" || input.ToLower() == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Eingabe nicht ´bekannt");
                }



                


    }
        }
        static void TryBuy(string item, int cost, Player p)
        {
            if (p.coins >= cost)// Variablen werden erhöht. 
            {
                if (item == "trank")
                    p.potion++;
                else if (item == "waffe")
                    p.weaponValue++;
                else if (item == "rüstung")
                    p.armorValue++;
                p.coins -= cost;
                //else if (item == "kartenspiel")
                //Random Gelderspielen 

            }

            else
            {
                Console.WriteLine("Du hast nicht genug Münzen..");
                Console.ReadKey();
            }
            Console.ReadKey();

        }
    }
}
