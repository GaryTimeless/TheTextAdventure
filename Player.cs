using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace Text.Adv.mit_Greg
{
    [Serializable()]
    public class Player : ISerializable
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


        public Player (){}

        public static Player p = new Player();
      

        public static void TravelBag()
        {
            Console.WriteLine("You got " + Player.p.potion +" potions");
            Console.WriteLine("You got " + Player.p.coins + " Septime");
            Console.ReadKey();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("Name", name);
            info.AddValue("Coins", coins);
            info.AddValue("health", health);
            info.AddValue("damage", damage);
            info.AddValue("armorValue", armorValue);
            info.AddValue("potion", potion);
            info.AddValue("weaponValue", weaponValue);
            info.AddValue("runspeed", runspeed);
            info.AddValue("typ", typ);
            info.AddValue("CurrentCity", CurrentCity);
            info.AddValue("Level", Level);

        }

        public Player(SerializationInfo info, StreamingContext context)
        {
            name = (string)info.GetValue("Name", typeof(string));
            coins = (int)info.GetValue("Coins", typeof(int));
            health = (int)info.GetValue("health", typeof(int));
            damage = (int)info.GetValue("damage", typeof(int));
            armorValue = (int)info.GetValue("armorValue", typeof(int));
            potion = (int)info.GetValue("potion", typeof(int));
            weaponValue = (int)info.GetValue("weaponValue", typeof(int));
            runspeed = (int)info.GetValue("runspeed", typeof(int));
            typ = (string)info.GetValue("typ", typeof(string));
            CurrentCity = (City)info.GetValue("CurrentCity", typeof(City));
            Level = (int)info.GetValue("Level", typeof(int));

        }

        
    }
   
}