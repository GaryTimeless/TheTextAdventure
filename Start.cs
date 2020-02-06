using System;
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

        
        


        public static bool mainloop = true;
       
        public static Random rand = new Random();
        

        public static void CreatePlayer()
        {
            Console.WriteLine(Pics.title);
            Console.WriteLine(@" Welcome to the Text Adventrue The myth of Ra-e Kesh.


            You arrived at Ra - e Kesh.A land divided in 3 regions.



            The forest of Raash

                    the springs of Nasmah


                            & Metherwhere

            Feel free to look arround, master your discipline and
            encounter legends, myths and the unknown...");
                 Console.WriteLine("Whats your name? ");
    
          Player.p.name = Console.ReadLine();
                     Console.ReadKey();
                         Console.Clear();
          Console.WriteLine("Willkommen " + Player.p.name + " um dich in dieser Welt zurecht zufinden benutze bitte die möglichen Befehle und Enter");
           
            Console.ReadKey();
            Console.Clear();
        }

        public static void ChooseFraction() 
        {
            Console.WriteLine(@"Welcome " + Player.p.name + @" to Ra-e Kesh


                        please choose your discipline
                        1.Warrior
                        2.Magician
                        ");

            Console.WriteLine("Please enter a number between the given options.");
           int typ = Convert.ToInt32(Console.ReadLine());
          
              

            switch (typ) 
            {
                case 1:
            Player.p.health = 15;
            Player.p.damage = 1;
            Player.p.coins = 100;
            Player.p.armorValue = 2;
            Player.p.runspeed = 5;
            Player.p.potion = 5;
            Player.p.weaponValue = 1;
            Player.p.typ = "warrior";
            Player.p.CurrentCity = City.Drana;
            Player.p.Level = 1;


                    Text.Adv.mit_Greg.SaveGame.SaveGameData(); 

            break;
            case 2:

            Player.p.health = 10;
            Player.p.damage = 2;
            Player.p.coins = 20000;
            Player.p.armorValue = 1;
            Player.p.runspeed = 3;
            Player.p.potion = 10;
            Player.p.weaponValue = 1;
            Player.p.typ = "magician";
            Player.p.CurrentCity = City.Mandrial;
            Player.p.Level = 1;

                    Text.Adv.mit_Greg.SaveGame.SaveGameData();


                    break;
                  
            }
            Console.Clear();
            Console.WriteLine("<>============================<>");
            Console.WriteLine("<><><><><><><><><><><><><><><><>><><><><><><>><><><><><><>");
            Console.WriteLine("You chose to be a " + Player.p.typ);
            Console.WriteLine("<>===========" + Player.p.name + "=============================<>");
            Console.WriteLine("<>|Münzen " + Player.p.coins);
            Console.WriteLine("<>|                          ");
            Console.WriteLine("<>|Waffenstärke " + Player.p.weaponValue);
            Console.WriteLine("<>|                          ");
            Console.WriteLine("<>|Rüstungstärke: " + Player.p.armorValue);
            Console.WriteLine("<>|                          ");
            Console.WriteLine("<>|Tränke " + Player.p.potion);
            Console.WriteLine("<>======================================================<>");
            Console.WriteLine("<><><><><><><><><><><><><><><><>><><><><><><>><><><><><><>");

        }


    
    }
}