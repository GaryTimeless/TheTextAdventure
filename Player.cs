using System;
using System.Collections.Generic;
using System.Text;

namespace Text.Adv.mit_Greg
{
   public class Player//
    {
        public string name;
        public int coins = 0;
        public int health = 0;
        public int damage = 0;
        public int armorValue = 0;
        public int potion = 0;
        public int weaponValue = 0;
        public int runspeed = 0;
        public string typ;
        public City CurrentCity;
        public int Level;
        
        //public int id;

        public int mods = 0;
        
        public string ImportCity;
        public int GetHealth()
        {
            int upper = (2 * mods + 5);
            int lower = (mods + 2);
            return Program.rand.Next(lower, upper);
        }
        public int GetPower()
        {
            int upper = (2 * mods + 5);
            int lower = (mods + 1);
            return Program.rand.Next(lower, upper);
        }
        public int GetCoins()
        {
            int upper = (2 * mods + 4);
            int lower = (mods + 2);
            return Program.rand.Next(lower, upper);
        }

        public static Player p = new Player();

        public static void TravelBag()
        {
            Console.WriteLine("You got " + Player.p.potion +" potions");
            Console.WriteLine("You got " + Player.p.coins + " Septime");
            Console.ReadKey();
        }
    }
   
}