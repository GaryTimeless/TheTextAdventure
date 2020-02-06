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


    public class Program
    {
        public static Random rand = new Random();
        static Regex ChooseMenue = new Regex("^[1-4]$");  // ("^[]$")


        static void Main(string[] args)
        {

            

            Text.Adv.mit_Greg.City.CreateCity();
            Text.Adv.mit_Greg.QuestNPC.CreateNPC();
            while (true) 
            {
                Console.WriteLine(@"
                
                What do you want to do?
                Please enter with the first letter of given options.
                1. (S)tart a new game.
                2. (L)oad a old one.   
     
                ");

                string input = Console.ReadLine();

                if (input.ToLower() == "s" || input.ToLower() == "start")
                {
                    Try9();
                }
                else if (input.ToLower() == "l" || input.ToLower() == "load")
                {
                    Try8();
                }
              
                break;
            }
            static void Try9()
            {
                Text.Adv.mit_Greg.Start.CreatePlayer();
                Text.Adv.mit_Greg.Start.ChooseFraction();
            }
            static void Try8()
            {
                Text.Adv.mit_Greg.SaveGame.LoadPlayerData();
            }

            while (true)
            {
                // Console.WriteLine(Game.UserAvatar.STATS);

                //  Console.WriteLine(Game.UserAvatar.CurrentCity.Name);
                Console.Clear();

                Console.WriteLine(Player.p.health + "\n" + Player.p.damage + "\n" + Player.p.coins + "\n" + Player.p.armorValue + "\n" + Player.p.runspeed + "\n" + Player.p.potion +
                 "\n" + Player.p.weaponValue + "\n" + Player.p.typ + "\n" + Player.p.CurrentCity.Name + "\n" + Player.p.Level);

                Console.WriteLine(@"
                
                What do you want to do?
                Please enter with the first letter of given options.
                1. (T)ravel to another city
                2. (L)ook arround
                3. (C)heck my travelBag
                4. (E)nd Game
                <> (S)ave game<>
                ");
                string input = Console.ReadLine();

                if (input.ToLower() == "s" || input.ToLower() == "save")
                {
                    Try7();
                }
                if (input.ToLower() == "t" || input.ToLower() == "travel")
                {
                    Try1();
                }
                else if (input.ToLower() == "l" || input.ToLower() == "Look")
                {
                    Try2(); 
                }
                else if (input.ToLower() == "c" || input.ToLower() == "check")
                {
                    Try4(); 
                }
                else if (input.ToLower() == "e" || input.ToLower() == "end")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("input is invalid");
                }
            }

        }
        static void Try1()
        {
            Travel.nextCity();
        }
        static void Try2()
        {
            Quest.StoryLine(Player.p.CurrentCity);
        }
        static void Try4()
        {
            Player.TravelBag();
        }
        static void Try7()
        {
            Text.Adv.mit_Greg.SaveGame.SaveGameData();
        }

    }
    
}
