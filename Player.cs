﻿using System;
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
        //public int id;

        public int mods = 0;
        //public City CurrentCity;
        // public string ImportCity;

        public static Player p = new Player();

        public static void TravelBag()
        {
            Console.WriteLine("You got " + Player.p.potion +"potions");

        }
    }
   
}