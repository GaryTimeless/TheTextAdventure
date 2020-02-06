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

            Text.Adv.mit_Greg.Start.CreatePlayer();
            Text.Adv.mit_Greg.Start.ChooseFraction();

            Text.Adv.mit_Greg.City.CreateCity();
            Text.Adv.mit_Greg.QuestNPC.CreateNPC();
            while (true)
            {
                // Console.WriteLine(Game.UserAvatar.STATS);

                //  Console.WriteLine(Game.UserAvatar.CurrentCity.Name);
                Console.Clear();
                Console.WriteLine(@"
                
                What do you want to do?
                Please enter with the first letter of given options.
                1. (T)ravel to another city
                2. (L)ook arround
                3. (C)heck my travelBag
                4. (E)nd Game
                <>(V) für verlassen <>
                <>(B) für beenden und speichern<>
                ");
                string input = Console.ReadLine();

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

    }
    
}
