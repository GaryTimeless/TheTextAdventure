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
    public class SaveGame
    {

       
        


        public static void SaveGameData()
        {

            String SAVEGAME = (Player.p.health + "\n" + Player.p.damage + "\n" + Player.p.coins + "\n" + Player.p.armorValue + "\n" + Player.p.runspeed + "\n" + Player.p.potion +
                 "\n" + Player.p.weaponValue + "\n" + Player.p.typ + "\n" + Player.p.CurrentCity.Name + "\n" + Player.p.Level);

            Console.WriteLine(SAVEGAME);

            Console.ReadKey();

            StreamWriter SaveAvatarDATA = null;

            SaveAvatarDATA = new StreamWriter(Player.p.name + ".txt");
            SaveAvatarDATA.Write(SAVEGAME);
            SaveAvatarDATA.Close();


        }
        public static void LoadPlayerData()
        {
            StreamReader ImportAvatarDATA = null;
            Console.WriteLine("Please Enter your Name, to Load your last Game: ");
            Player.p.name = Console.ReadLine();

            ImportAvatarDATA = new StreamReader(Player.p.name + ".txt");

            Player.p.health = Convert.ToInt32(ImportAvatarDATA.ReadLine());
            Player.p.damage = Convert.ToInt32(ImportAvatarDATA.ReadLine());
            Player.p.coins = Convert.ToInt32(ImportAvatarDATA.ReadLine());
            Player.p.armorValue = Convert.ToInt32(ImportAvatarDATA.ReadLine());
            Player.p.runspeed = Convert.ToInt32(ImportAvatarDATA.ReadLine());
            Player.p.potion = Convert.ToInt32(ImportAvatarDATA.ReadLine());
            Player.p.weaponValue = Convert.ToInt32(ImportAvatarDATA.ReadLine());
            Player.p.typ = ImportAvatarDATA.ReadLine();
            Player.p.ImportCity = ImportAvatarDATA.ReadLine();
            Player.p.Level = Convert.ToInt32(ImportAvatarDATA.ReadLine());

            ImportHashSetCity(Player.p.ImportCity);

            ImportAvatarDATA.Close();

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
            Console.ReadKey();


        }

        public static void ImportHashSetCity(string ImportCity)
        {
            City[] CityHASHTABELLE = new City[100];


            CityHASHTABELLE[4] = City.Drana;
            CityHASHTABELLE[2] = City.Bort;
            CityHASHTABELLE[20] = City.TorVonHundrial;
            CityHASHTABELLE[13] = City.Mandrial;
            CityHASHTABELLE[18] = City.Ranador;
            CityHASHTABELLE[19] = City.SaeIlaas;
            CityHASHTABELLE[15] = City.Openworld;

            char FirstLetterHash = ImportCity[0];
            int HashtableNumber = FirstLetterHash - 64;
            Player.p.CurrentCity = CityHASHTABELLE[HashtableNumber];

        }




        /*
        
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

            break;
            case 2:

            Player.p.health = 10;
            Player.p.damage = 2;
            Player.p.coins = 200;
            Player.p.armorValue = 1;
            Player.p.runspeed = 3;
            Player.p.potion = 10;
            Player.p.weaponValue = 1;
            Player.p.typ = "magician";
            Player.p.CurrentCity = City.Mandrial;
            Player.p.Level = 1;

    
    */




    }
}