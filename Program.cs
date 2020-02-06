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
        static Regex ChooseLoadNEW = new Regex("^[s|l]$");
        static Regex ChooseMainMenue = new Regex("^[t|l|c|e|s]$");// ("^[]$")


        static void Main(string[] args)
        {

            

            Text.Adv.mit_Greg.City.CreateCity();
            Text.Adv.mit_Greg.QuestNPC.CreateNPC();
            while (true) 
            {

                string input = "";
                while (!ChooseLoadNEW.IsMatch(input.ToString()))
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine(@"
                
                What do you want to do?
                Please enter with the first letter of given options.
                1. (S)tart a new game.
                2. (L)oad a old one.   
     
                ");

                        Console.WriteLine("please Enter one of the letters in brackets");
                        input = Console.ReadLine();
                        

                    }
                    catch
                    {
                        Console.WriteLine("Invalid.");


                    }

                }

               

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
                string input = "";
                while (!ChooseMainMenue.IsMatch(input.ToString()))
                {
                    try
                    {


                        Console.WriteLine(@"Typ: " + Player.p.typ + "\n" +
                                   "Health: " + Player.p.health + "\n" +
                                   "Damage: " + Player.p.damage + "\n" +
                                   "ArmorValue: " + Player.p.armorValue + "\n" +
                                   "Runspeed: " + Player.p.runspeed + "\n" +
                                   "WeaponValue: " + Player.p.weaponValue + "\n" +

                                   "Coins: " + Player.p.coins + "\n" +
                                   "Potion: " + Player.p.potion + "\n" +

                                   "Level: " + Player.p.Level);

                        Console.WriteLine(@"
                
                        What do you want to do?
                        Please enter with the first letter of given options.
                        1. (T)ravel to another city
                        2. (L)ook arround
                        3. (C)heck my travelBag
                        4. (E)nd Game
                        <> (S)ave game<>
                        ");
                        input = Console.ReadLine();
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input");
                    }

                }

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
