﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Text.Adv.mit_Greg
{
    public class SaveGame
    {



        // klappt noch nicht. Arbeite daran.
        public static void SaveGameDataSerialXML()
        {

            
           XmlSerializer SaveData = new XmlSerializer(typeof(Player));
            

            using (TextWriter WriteSaveData = new StreamWriter(Player.p.name + ".dat"))
            {

                SaveData.Serialize(WriteSaveData, Player.p);

            }
        }
        public static void LoadGameDataSerialXML()
        {

            XmlSerializer LoadData = new XmlSerializer(typeof(Player));

            using (TextReader ReadLoadData = new StreamReader(Player.p.name + ".dat"))
            {
                Player.p = (Player)LoadData.Deserialize(ReadLoadData);
            }
        }

    
        // funktioniert, wäre aber cooler wenn XML klappt
        public static void SaveGameDataSERIALBINARY()
        {
            BinaryFormatter SaveAvatarData = new BinaryFormatter();
            FileStream DataPath = new FileStream(Player.p.name + ".txt", FileMode.Create, FileAccess.Write);

            SaveAvatarData.Serialize(DataPath, Player.p);
            DataPath.Close();

            Console.WriteLine("YOU SAVED YOUR DATA");
            Console.ReadKey();




        }
        public static void LoadGameDataSERIALBINARY()
        {
            BinaryFormatter LoadAvatarData = new BinaryFormatter();

            Console.WriteLine("Bitte gebe den Namen ein um dein Spiel zu laden");
            Player.p.name = Console.ReadLine();

            FileStream DataPath = new FileStream(Player.p.name + ".txt", FileMode.Open, FileAccess.Read);

            Player.p = (Player)LoadAvatarData.Deserialize(DataPath);

        }

        // just a .txt -> will be deleted soon.
        public static void SaveGameData()
        {

            String SAVEGAME = (Player.p.health + "\n" + Player.p.damage + "\n" + Player.p.coins + "\n" + Player.p.armorValue + "\n" + Player.p.runspeed + "\n" + Player.p.potion +
                 "\n" + Player.p.weaponValue + "\n" + Player.p.typ + "\n" + Player.p.CurrentCity.Name + "\n" + Player.p.Level);

            Console.WriteLine(@"Typ: " + Player.p.typ + "\n" +
                                   "Health: " + Player.p.health + "\n" +
                                   "Damage: " + Player.p.damage + "\n" +
                                   "ArmorValue: " + Player.p.armorValue + "\n" +
                                   "Runspeed: " + Player.p.runspeed + "\n" +
                                   "WeaponValue: " + Player.p.weaponValue + "\n" +

                                   "Coins: " + Player.p.coins + "\n" +
                                   "Potion: " + Player.p.potion + "\n" +

                                   "Level: " + Player.p.Level);

            Console.WriteLine("SpeicherDatei wurde erstell.");

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