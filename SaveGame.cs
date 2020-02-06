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

        StreamWriter CreateNewAvatarDATA = null;
        StreamReader ImportAvatarDATA = null;


        public static void SaveGameData()
        {

            String SAVEGAME = (Player.p.health + "\n" + Player.p.damage + "\n" + Player.p.coins + "\n" + Player.p.armorValue + "\n" + Player.p.runspeed + "\n" + Player.p.potion +
                 "\n" + Player.p.weaponValue + "\n" + Player.p.typ + "\n" + Player.p.CurrentCity + "\n" + Player.p.Level);

            Console.WriteLine(SAVEGAME);

            Console.ReadKey();

            StreamWriter SaveAvatarDATA = null;

            SaveAvatarDATA = new StreamWriter(Player.p.name + ".txt");
            SaveAvatarDATA.Write(SAVEGAME);
            SaveAvatarDATA.Close();


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