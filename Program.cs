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

        static Regex ChooseMenue = new Regex("^[1-4]$");  // ("^[]$")


        static void Main(string[] args)
        {

            Text.Adv.mit_Greg.Start.CreatePlayer();
            Text.Adv.mit_Greg.Start.ChooseFraction();

      
            int Counter = 0;

            while (Counter == 0)
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
                    Travel.nextCity();
                }
                else if (input.ToLower() == "l" || input.ToLower() == "Look")
                {
                    Quest.StoryLine();
                }
                else if (input.ToLower() == "C" || input.ToLower() == "check")
                {
                    Player.TravelBag();
                }
                else if (input.ToLower() == "b" || input.ToLower() == "beenden")
                {
                    Environment.Exit(1);
                }
                else if (input.ToLower() == "v" || input.ToLower() == "verlassen")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("input is invalid");
                }
            }
      


        }

    }
    
}
