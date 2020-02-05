using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

public class Avatar
{
    public string Name;
    public int ATK;
    public int DEF;
    public int AGIL;
    public int LUCK;
    public string TYP;
    public string STATS;
    public int Level;
    public int Money;

    public City CurrentCity;
    public string ImportCity;




}
public struct Area
{
    public string Name;
    public string City;


}

public class City
{
    public string Name;
    public int Temper;
    public Area AreaWhereTheCityIs;

    public List<City> nearCityLIST;


    public List<Area> travelOptionArea;
    public List<string> AllCityNames;
    public string StreetsName;
    public string TavernName;

    public List<QuestNPC> StreetNPCList;
    public List<QuestNPC> TavernNPCList;

    


    /*public City(string nm)
    {
        this.Name = nm;
    }
    */

}




public static class Game

{

    static Regex nurZahlen19 = new Regex("^[1-9]$");
    static Regex ChooseAvatar = new Regex("^[1-3]$");
    static Regex ChooseTravel = new Regex("^[1-4]$");
    


    // some basic variables
    public static Avatar UserAvatar = new Avatar();
    public static Area ForestOfRaash, SpringOfNasmah, Metherwhere;
    public static City Drana = new City(), Bort = new City(), TorVonHundrial = new City(), Ranador = new City(), Mandrial = new City(), SaeIlaas = new City(), Openworld = new City();

   




    public static void ImportCityData(string ImportCurrentCity, List<string> allCityNames, List <City> allCity)
    {

        for (int i = 0; i < allCityNames.Count; ++i)

            if (allCityNames[i] == ImportCurrentCity)
            {
                UserAvatar.CurrentCity = allCity[i];
            }


    }
    

    public static void CreateCity()
    {





        ForestOfRaash.Name = "forest of Raash";
        // Forest of Raash
        Drana.Name = "Drana";
        Bort.Name = "Bort";
        TorVonHundrial.Name = "Tor von Hundrial";

        Drana.AreaWhereTheCityIs = ForestOfRaash;
        Bort.AreaWhereTheCityIs = ForestOfRaash;
        TorVonHundrial.AreaWhereTheCityIs = ForestOfRaash;


        // travel options
        Drana.nearCityLIST = new List<City>() { Bort, TorVonHundrial };
        Bort.nearCityLIST = new List<City>() { Drana, TorVonHundrial };
        
        TorVonHundrial.nearCityLIST = new List<City>() { Drana, Bort, SaeIlaas };


        Drana.StreetNPCList = new List<QuestNPC>() { QuestNPC.Imartak };
        Drana.StreetsName = "street of fallen warrior";
        Drana.TavernName = "Boldly Bear";

        Bort.StreetNPCList = new List<QuestNPC>() { QuestNPC.Rahl };
        Bort.StreetsName = "street of vengeful sinners";
        Bort.TavernName = "suicide silence";



        ForestOfRaash.City = Drana.Name + Bort.Name + TorVonHundrial.Name;

        SpringOfNasmah.Name = " spring of Nasmah";
        // Spring of Nasmah

        Ranador.Name = "Ranador";
        Mandrial.Name = "Mandrial";
        SaeIlaas.Name = "SaeIlaas";

        Ranador.AreaWhereTheCityIs = SpringOfNasmah;
        Mandrial.AreaWhereTheCityIs = SpringOfNasmah;
        SaeIlaas.AreaWhereTheCityIs = SpringOfNasmah;

        // travel options
        Mandrial.nearCityLIST = new List<City>() { Ranador, SaeIlaas };
        Ranador.nearCityLIST = new List<City>() { Mandrial, SaeIlaas };
        SaeIlaas.nearCityLIST = new List<City>() { Ranador, SaeIlaas, Mandrial, TorVonHundrial };



        Metherwhere.Name = "Metherwhere";
        Openworld.Name = "Openworld";
        Openworld.nearCityLIST = new List<City>() { Openworld };
        Openworld.AreaWhereTheCityIs = Metherwhere;





    }
    



    public static void StartGame()
     {
        BGWhite(@"

            Welcome to the Text Adventrue The myth of Ra-e Kesh.
            
            You arrived at Ra-e Kesh. A land divided in 3 regions.
            
            
            The forest of Raash

                    the springs of Nasmah

             
                            & Metherwhere

            Feel free to look arround, master your discipline and 
            encounter legends, myths and the unknown...
                                                            ");




        

        // Create Avatar

        Console.WriteLine("How do you call yourself?");

        Regex nurBuchstaben = new Regex("^[A-Z][a-z]+$");

        UserAvatar.Name = Console.ReadLine();

        while(!nurBuchstaben.IsMatch(UserAvatar.Name))
        {
            Console.Clear();
            Console.WriteLine("Bitte geben sie einen Konformen Namen ein:");
            UserAvatar.Name = Console.ReadLine();
        }
       
        


        

        Console.WriteLine(@"
                        Welcome " + UserAvatar.Name + @" to Ra-e Kesh


                        please choose your discipline
                        1. Warrior 
                        2. Mage
                        3. Rogue");

        int typ = 0;
        while (!ChooseAvatar.IsMatch(typ.ToString()))
        {
            try
            {
                Console.WriteLine("Please enter a number between the given options.");
                typ = Convert.ToInt32(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Invalid.");

            }



            
        }

        Console.Clear();
      
      

        StreamWriter CreateNewAvatarDATA = null;
        StreamReader ImportAvatarDATA = null;


      // List<City> allCityList = new List<City>() { Drana, Bort, TorVonHundrial, Ranador, Mandrial, SaeIlaas, Openworld };
      //List<string> allCityNameList = new List<string>() { Drana.Name, Bort.Name, TorVonHundrial.Name, Ranador.Name, Mandrial.Name, SaeIlaas.Name, Openworld.Name };

        


        // Choose Avatar - Create Avatar
        switch (typ)
        {
            case 1:

                
                String Warrior = "warrior\n5\n3\n1\n3\nDrana\n1\n0\n";

               

                CreateNewAvatarDATA = new StreamWriter(UserAvatar.Name + ".txt");
                CreateNewAvatarDATA.Write(Warrior);
                CreateNewAvatarDATA.Close();


                ImportAvatarDATA = new StreamReader(UserAvatar.Name + ".txt");

                UserAvatar.TYP = ImportAvatarDATA.ReadLine();
                UserAvatar.ATK = Convert.ToInt32(ImportAvatarDATA.ReadLine());
                UserAvatar.DEF = Convert.ToInt32(ImportAvatarDATA.ReadLine());
                UserAvatar.AGIL = Convert.ToInt32(ImportAvatarDATA.ReadLine());
                UserAvatar.LUCK = Convert.ToInt32(ImportAvatarDATA.ReadLine());
                UserAvatar.ImportCity = ImportAvatarDATA.ReadLine();
                UserAvatar.Level = Convert.ToInt32(ImportAvatarDATA.ReadLine());
                UserAvatar.Money = Convert.ToInt32(ImportAvatarDATA.ReadLine());
               


                ImportHashSetCity(UserAvatar.ImportCity);

                ImportAvatarDATA.Close();

                UserAvatar.STATS = (UserAvatar.TYP + "\n" +
                                            "Attack: " + UserAvatar.ATK + "\n" +
                                            "Defense: " + UserAvatar.DEF + "\n" +
                                            "Agile: " + UserAvatar.AGIL + "\n" +
                                            "Luck: " + UserAvatar.LUCK + "\n" +
                                            "Level: " + UserAvatar.Level + ".\n" +
                                            "Money:" + UserAvatar.Money);

                TextWarrior(@"You choose the path to become a " + UserAvatar.STATS +

                "The forests of Raash is the origin of the ort of legendary warriors. You are in a rough city called DRANA, where everybody is trying to get a strong mind, strong body and show no mercy");

                Console.ReadKey();
                
                break;
            case 2:
                Console
                    .BackgroundColor = ConsoleColor.Blue;


                String Mage = "mage\n2\n3\n4\n5\nMandrial\n1\n";

                

                CreateNewAvatarDATA = new StreamWriter(UserAvatar.Name + ".txt");
                CreateNewAvatarDATA.Write(Mage);
                CreateNewAvatarDATA.Close();


                ImportAvatarDATA = new StreamReader(UserAvatar.Name + ".txt");

                UserAvatar.TYP = ImportAvatarDATA.ReadLine();
                UserAvatar.ATK = Convert.ToInt32(ImportAvatarDATA.ReadLine());
                UserAvatar.DEF = Convert.ToInt32(ImportAvatarDATA.ReadLine());
                UserAvatar.AGIL = Convert.ToInt32(ImportAvatarDATA.ReadLine());
                UserAvatar.LUCK = Convert.ToInt32(ImportAvatarDATA.ReadLine());
                UserAvatar.ImportCity = ImportAvatarDATA.ReadLine();
                UserAvatar.Level = Convert.ToInt32(ImportAvatarDATA.ReadLine());


                ImportHashSetCity(UserAvatar.ImportCity);
                ImportAvatarDATA.Close();




                UserAvatar.STATS = (UserAvatar.TYP + "\n" +
                                            "Attack: " + UserAvatar.ATK + "\n" +
                                            "Defense: " + UserAvatar.DEF + "\n" +
                                            "Agile: " + UserAvatar.AGIL + "\n" +
                                            "Luck: " + UserAvatar.LUCK + "\n" + 
                                            "Level: " + UserAvatar.Level + ".\n");

                TextYellow("You choose the path to become a " + UserAvatar.STATS +

                "The origin of all magic lies in the springs of Nasmah." +
                "You are in an astonishing city called Mandrial. " +
                "Elegance, gracefulness and discipline are reflected wherever you are looking.");




                Console.ReadKey();
                Console.ResetColor();
                break;
            case 3:
                Console.BackgroundColor = ConsoleColor.White;

                String Rogue = "rogue\n4\n1\n5\n2\nOpenworld\n1\n";

                

                CreateNewAvatarDATA = new StreamWriter(UserAvatar.Name + ".txt");
                CreateNewAvatarDATA.Write(Rogue);
                CreateNewAvatarDATA.Close();


                ImportAvatarDATA = new StreamReader(UserAvatar.Name + ".txt");


                // überprüfung das alles Stats nie <0 werden dürfen.
                UserAvatar.TYP = ImportAvatarDATA.ReadLine();
                UserAvatar.ATK = Convert.ToInt32(ImportAvatarDATA.ReadLine());
                UserAvatar.DEF = Convert.ToInt32(ImportAvatarDATA.ReadLine());
                UserAvatar.AGIL = Convert.ToInt32(ImportAvatarDATA.ReadLine());
                UserAvatar.LUCK = Convert.ToInt32(ImportAvatarDATA.ReadLine());
                UserAvatar.ImportCity = ImportAvatarDATA.ReadLine();
                UserAvatar.Level = Convert.ToInt32(ImportAvatarDATA.ReadLine());


                ImportHashSetCity(UserAvatar.ImportCity);

                ImportAvatarDATA.Close();


                // override To.String
                UserAvatar.STATS = (UserAvatar.TYP + "\n" +
                                            "Attack: " + UserAvatar.ATK + "\n" +
                                            "Defense: " + UserAvatar.DEF + "\n" +
                                            "Agile: " + UserAvatar.AGIL + "\n" +
                                            "Luck: " + UserAvatar.LUCK + "\n" +
                                            "Level: " + UserAvatar.Level + ".\n");

                Console.WriteLine(@"You choose the path to become a " + UserAvatar.STATS +

                "The ones who wander through Metherwhere never loose a word about how it looks like. Nobody knows the reason why." +
                "And those who tried to force the answer have been cursed...");

                Console.ReadKey();
                break;
        }

        ImportAvatarDATA.Close();
        CreateNewAvatarDATA.Close();
    }

    public static void ImportHashSetCity(string ImportCity)
    {
        City[] CityHASHTABELLE = new City[100];


        CityHASHTABELLE[4] = Drana;
        CityHASHTABELLE[2] = Bort;
        CityHASHTABELLE[20] = TorVonHundrial;
        CityHASHTABELLE[13] = Mandrial;
        CityHASHTABELLE[18] = Ranador;
        CityHASHTABELLE[19] = SaeIlaas;
        CityHASHTABELLE[15] = Openworld;

        char FirstLetterHash = ImportCity[0];
        int HashtableNumber = FirstLetterHash - 64;
        UserAvatar.CurrentCity = CityHASHTABELLE[HashtableNumber];

        





    }

    public static void nextCity()
    {
        Console.WriteLine(@"You are in the City: " + UserAvatar.CurrentCity.Name + " in " + UserAvatar.CurrentCity.AreaWhereTheCityIs.Name);
       
    

       

        int cheklength = UserAvatar.CurrentCity.nearCityLIST.Count;


            Console.WriteLine(@"You can travel to the City: ");

            for (int i = 0; i < cheklength; ++i)
            {
                Console.WriteLine(@"
                    
                                    " + (i + 1) + ")" + UserAvatar.CurrentCity.nearCityLIST[i].Name + " in " + UserAvatar.CurrentCity.nearCityLIST[i].AreaWhereTheCityIs.Name);
            }
            Console.WriteLine(@"Where you do you want to travel? ");


        


        int ChooseTravelOption = 0;
        

        while (!ChooseTravel.IsMatch(ChooseTravelOption.ToString()))
        {
            try
            {

                Console.WriteLine("Please enter a number between the given options.");
                ChooseTravelOption = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {

                Console.WriteLine(@"invalid.");

            }
        }

        switch (ChooseTravelOption)
            {
                case 1:
                    UserAvatar.CurrentCity = UserAvatar.CurrentCity.nearCityLIST[0];
                break;
                case 2:
                    UserAvatar.CurrentCity = UserAvatar.CurrentCity.nearCityLIST[1];
                break;
                case 3:
                    UserAvatar.CurrentCity = UserAvatar.CurrentCity.nearCityLIST[2];
                break;
                case 4:
                UserAvatar.CurrentCity = UserAvatar.CurrentCity.nearCityLIST[3];
                break;
        }

        Console.WriteLine("You are now in: " + UserAvatar.CurrentCity.Name + " in " + UserAvatar.CurrentCity.AreaWhereTheCityIs.Name);
        Console.ReadKey();
    
   
    }



    public static void TextCyan(string Message)

    {

        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.Write(Message);

        Console.ResetColor();





    }
    public static void TextWarrior(string Message)
    {

        Console.BackgroundColor = ConsoleColor.Black;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Clear();
        Console.Write(Message);
        Console.ResetColor();

    }


    public static void TextRed(string Message)

    {

        Console.ForegroundColor = ConsoleColor.Red;

        Console.Write(Message);

        Console.ResetColor();

    }



    public static void TextYellow(string Message)

    {

        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.Write(Message);

        Console.ResetColor();

    }

    public static void BGWhite(string Message)
    {

        Console.BackgroundColor = ConsoleColor.Black;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Clear();
        Console.Write(Message);

        Console.ReadKey();

        Console.ResetColor();

        Console.Clear();

    }


}

// END CLASS GAME                  END CLASS GAME                  END CLASS GAME


public class LoadGame
{



    public static void ImportGame()
    {

        StreamReader ImportAvatarDATA = null;
        

        for (int i = 0; i <100; ++i)

        {
            Regex nurBuchstaben = new Regex("^[A-Z][a-z]+$");
            string XXX = "";
            while (!nurBuchstaben.IsMatch(XXX))
            {
                try
                {
                    Console.WriteLine("Please Enter your Name, to Load your last Game: ");
                    Game.UserAvatar.Name = Console.ReadLine();
                    ImportAvatarDATA = new StreamReader(Game.UserAvatar.Name + ".txt");
                    XXX = Game.UserAvatar.Name;
                }
                catch
                {
                    Console.WriteLine("There is no file with this Name");


                }
            }
            i = 100;
        }
      
        Game.UserAvatar.TYP = ImportAvatarDATA.ReadLine();
        Game.UserAvatar.ATK = Convert.ToInt32(ImportAvatarDATA.ReadLine());
        Game.UserAvatar.DEF = Convert.ToInt32(ImportAvatarDATA.ReadLine());
        Game.UserAvatar.AGIL = Convert.ToInt32(ImportAvatarDATA.ReadLine());
        Game.UserAvatar.LUCK = Convert.ToInt32(ImportAvatarDATA.ReadLine());
        Game.UserAvatar.ImportCity = ImportAvatarDATA.ReadLine();
        Game.UserAvatar.Level =Convert.ToInt32(ImportAvatarDATA.ReadLine());
        Game.UserAvatar.STATS = (Game.UserAvatar.TYP + "\n" +
                                            "Attack: " + Game.UserAvatar.ATK + "\n" +
                                            "Defense: " + Game.UserAvatar.DEF + "\n" +
                                            "Agile: " + Game.UserAvatar.AGIL + "\n" +
                                            "Luck: " + Game.UserAvatar.LUCK + "\n" + 
                                            "Level: " + Game.UserAvatar.Level + ".\n");
        Game.ImportHashSetCity(Game.UserAvatar.ImportCity);


        Console.Clear();
        Console.WriteLine("You are a: ");
        Game.TextRed(Game.UserAvatar.STATS);
        Console.WriteLine( "in the City " + Game.UserAvatar.CurrentCity.Name + " in " + Game.UserAvatar.CurrentCity.AreaWhereTheCityIs.Name);


        

        Console.ReadKey();



        ImportAvatarDATA.Close();

    }


    

}

// END LOAD GAME

public static class SaveGame
{


    public static void SaveGameDATA()
    {
      


        String SAVEGAME = Game.UserAvatar.TYP + "\n" + Game.UserAvatar.ATK + "\n" + Game.UserAvatar.DEF + "\n" + Game.UserAvatar.AGIL + "\n" + Game.UserAvatar.LUCK + "\n" + Game.UserAvatar.CurrentCity.Name + "\n" + Game.UserAvatar.Level; 

        Console.WriteLine(SAVEGAME);

        Console.ReadKey();

        StreamWriter SaveAvatarDATA = null;

        SaveAvatarDATA = new StreamWriter(Game.UserAvatar.Name + ".txt");
        SaveAvatarDATA.Write(SAVEGAME);
        SaveAvatarDATA.Close();












    }


}

class FirstMenue
{
    static Regex Arrow = new Regex("^[(&]$");
    static Regex Arrow2 = new Regex("^[%,(,&]$");



    //while (!ChooseMenue.IsMatch(chooseOption.ToString()))


    public static void FirstMenueChoose()
    {


                Console.WriteLine(@"Hello Fellow, what do you want to do?
                                   ///////////////////////////////////
                                   ///      start a new Game    ////
                                   ///      Continue            ////
                                   ///                          ////
                                  ///////////////////////////////////");
       




        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        
        string XXX = "";
        while (!Arrow.IsMatch(XXX.ToString()))
        {


            try
            {
                Console.WriteLine();
                Console.WriteLine("Please choose with Arrow UP and DOWN");

                keyInfo = Console.ReadKey();
                char keyInfoCHAR = (char)keyInfo.Key;
                XXX = keyInfoCHAR.ToString();
            }
            catch
            {

                Console.WriteLine("Invalid!");
            }

            
        }
        for (int i = 1; i < 100; ++i)
        {




            if ((char)keyInfo.Key == '(')
            {
                Console.Clear();
                Console.WriteLine(@"Hello Fellow, what do you want to do?
                               ///////////////////////////////////
                               ///      start a new Game    ////
                               ///   -> Continue            ////
                               ///                          ////
                              ///////////////////////////////////");


                Console.WriteLine("Please choose with Arrow UP and DOWN");

                keyInfo = Console.ReadKey();
                char keyInfoCHAR2 = (char)keyInfo.Key;
                XXX = keyInfoCHAR2.ToString();

                // ReadLine ""
                if ((char)keyInfo.Key == '%')
                {
                    
                    Console.ReadKey();
                    i = 100;

                    LoadGame.ImportGame();

                }

            }
            else if ((char)keyInfo.Key == '&')
            {
                Console.Clear();

                Console.WriteLine(@"Hello Fellow, what do you want to do?
                               ///////////////////////////////////
                               ///   -> start a new Game    ////
                               ///      Continue            ////
                               ///                          ////
                              ///////////////////////////////////");



                Console.WriteLine("Please choose with Arrow UP and DOWN");


                keyInfo = Console.ReadKey();
                char keyInfoCHAR = (char)keyInfo.Key;
                XXX = keyInfoCHAR.ToString();



                if ((char)keyInfo.Key == '%')
                {
                    Console.WriteLine("OKAY.Let´s start a new game");
                    Console.ReadKey();
                    i = 100;
                    Game.StartGame();


                }
            }
            else {

                while (!Arrow2.IsMatch(XXX.ToString()))
                {

                    try
                    {

                        Console.WriteLine("Please choose with Arrow UP and DOWN and Continue with ARROW LEFT");

                        keyInfo = Console.ReadKey();
                        char keyInfoCHAR = (char)keyInfo.Key;
                        XXX = keyInfoCHAR.ToString();
                    }
                    catch
                    {

                        Console.WriteLine("Invalid!");
                    }


                }


            }

        }    

    }


    // END FIRSTMENUECHOOSE
}
// END FIRST MENUE




class TravelBag
{

    public static void show()
    {

        Console.WriteLine("There is nothing inside your bag.");
        Console.ReadKey();
    }

}

public class QuestNPC
{
   public string Name;
   public int QuestProgress;




   public static QuestNPC Imartak = new QuestNPC();
   public static QuestNPC Rahl = new QuestNPC();



    public static void CreateNPC()
    {

        Imartak.Name = "old man";
        Imartak.QuestProgress = 0;

        Rahl.Name = "Rahl";
        Rahl.QuestProgress = 0;


      
    }


}

public class Quest
{





    public static void StoryLine(City QuestCity)
    {
        Console.WriteLine("In " + Game.UserAvatar.CurrentCity.Name + " you can:");

        Console.WriteLine("1). Walk along the " + Game.UserAvatar.CurrentCity.StreetsName);
        Console.WriteLine("2). Check out the tavern: " + Game.UserAvatar.CurrentCity.TavernName);
        Console.WriteLine("3). Visit the Shop ");

        if (QuestCity == Game.Drana)
        {
            int Choose = Convert.ToInt32(Console.ReadLine());
            switch (Choose)
            {
                case 1:
                    if (Game.UserAvatar.Level < 2)
                    {
                        Console.Clear();
                        ImartakQuest();
                    }



                    break;

                case 2:
                    Console.WriteLine("  As you approach the building, you notice the smell of alcohol, something to eat,\n"
                              +"         and a mixture of blood and sweat. There is a sign on the outside. Tavern: bold bear.\n"+
                              "          The tavern appears to be an old building. It is damaged in many places. \n"+
                              "          In detail, however,there are some elements typical of Raash. \n"+
                              "          The basic structure is made of Raashtan wood. The walls made of clay and stones \n"+
                              "          and the windows angular without glass. The characters in the beam of the house \n" +
                              "          that the roof supports are striking. STRONG BODY, STRONG MIND, NO MERCY. \n" +
                              "          But the tavern is closed... ");
                    Console.ReadKey();
                    Console.Clear();

                    break;
                case 3:

                    Console.WriteLine("WE ARE ON HOLIDAYS. Hope you don´t die while you try to survive without our outstanding eqip.\n" +
                        "              Save your money and come back later.");
                    break;



            }
        }
        else if (QuestCity == Game.Bort)
        {

            int Choose = Convert.ToInt32(Console.ReadLine());
            switch (Choose)
            {
                case 1:
                    if (Game.UserAvatar.Level < 2)
                    {
                        RahlQuest();
                    }

                    break;

                case 2:
                    Console.WriteLine("  As you approach the building, you notice the smell of alcohol, something to eat, and a mixture of blood and sweat. There is a sign on the outside. Tavern: bold bear.   The tavern appears to be an old building. It is damaged in many places. In detail, however,there are some elements typical of Raash. The basic structure is made of Raashtan wood. The walls made of clay and stones and the windows angular without glass. The characters in the beam of the house that the roof supports are striking. STRONG BODY, STRONG MIND, NO MERCY. But the tavern is closed... ");
                    Console.ReadKey();
                    Console.Clear();

                    break;
                case 3:

                    Console.WriteLine("WE ARE ON HOLIDAYS. Hope you don´t die while you try to survive without our outstanding eqip. Save your money and come back later.");
                    break;



            }




        }




        // Check out which city Useravatar is
        // check out which quest Useravatar already finished - with a new Data? OR with LVL.
        // open Next quest




       
    }




    public static void ImartakQuest()
    {


        switch (QuestNPC.Imartak.QuestProgress)
        {
            case 0:
                {
                    Console.WriteLine("You see an " + QuestNPC.Imartak.Name + " near a a fountain.\n" +
                                      "As you come closer the man pays you attention and smiled in greeting.");
                    Console.WriteLine();
                    Console.WriteLine(QuestNPC.Imartak.Name + ": You have that look of someone who is here for the first time.\n"+
                                                      "         And all people comming here are looking for the same two things.\n"+
                                                      "         MONEY or HONOR - mostly both.\n"+

                                                      "         What are you looking for?");

                    Console.WriteLine();
                    Console.WriteLine(Game.UserAvatar.Name + ":    1. Money\n"+
                                                             "         2. Honor");


                    int NOTHING = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();
                    Console.WriteLine(QuestNPC.Imartak.Name + ": Like I said. With honor I can not help you, it is best\n " +
                                                      "        to go to the bear. \n"  +
                                                      "         But I'm ready to give you some money if you do me a favor.");


                    Console.WriteLine();
                    Console.WriteLine(Game.UserAvatar.Name + ":    1. Okay, but what is the deal?\n"+
                                                      "         2. Hm.. maybe another time. Money is no important right now");



                    int MoneyOrHonor = Convert.ToInt32(Console.ReadLine());

                    if (MoneyOrHonor == 1)

                    {
                        Console.WriteLine(QuestNPC.Imartak.Name + ": The deal is that you have to travel to Bort.\n" + "" +
                                                       "         You should find a middle-aged man on the streets\n"+"" +
                                                       "         who is an old friend of mine.\n" +
                                                       "         He still trains me money. I need at least 500 Raash. \n"+
                                                       "         Tell him Imartak sends you. \n" +
                                                       "         I´ll give you 200 Raash for delivering. Do you help me out?");





                        Console.WriteLine();
                        Console.WriteLine(Game.UserAvatar.Name + ":    1. Yes, that should be easy!\n" +
                                                        "         2. No, I am not interested anymore...");
                        QuestNPC.Imartak.Name = "Imartak";
                        int AcceptQuest = Convert.ToInt32(Console.ReadLine());

                        if (AcceptQuest == 1)
                        {
                            Console.WriteLine(QuestNPC.Imartak.Name + ": Thank you. Watch out and don´t fight for nothing.");

                            // log into QuestLog
                            QuestNPC.Imartak.QuestProgress = 1;
                            QuestNPC.Rahl.QuestProgress = 1;
                            Console.ReadKey();
                            Console.Clear();

                        }
                        else
                        {
                            // back on the streets -> choose between man and tavern
                        }
                    }

                    break;
                }

            case 1:
                Console.WriteLine(QuestNPC.Imartak.Name + @": Oh you are Back. Did everthing worked well?");
                
                Console.ReadKey();
                if (Game.UserAvatar.Money == 500)
                {
                    Console.WriteLine(QuestNPC.Imartak.Name + @": YES, Thank you! Keep the 200");
                    Console.ReadKey();
                    Game.UserAvatar.Money = 300;
                    QuestNPC.Rahl.QuestProgress = 2;
                    QuestNPC.Imartak.QuestProgress = 2;

                    Console.WriteLine("You give Imartak the money");
                    Console.ReadKey();
                    Game.UserAvatar.Level = 1;
                    Console.WriteLine("Your Level increase: " + Game.UserAvatar.Level);
                    Console.ReadKey();



                }
                else {
                    Console.ReadKey();
                    Console.Clear();
                    TravelBag.show();
                    Console.ReadKey();
                    Console.WriteLine(QuestNPC.Imartak.Name + @": oh, okay. I was looking forward to. My fault.");
                    Console.ReadKey();
                }
                

                break;
            case 2:
                Console.WriteLine(QuestNPC.Imartak.Name + @": Good to see you again. I have nothing to do for you...");
                break;
        }

    }


    public static void RahlQuest()
    {


        // Zustand 1: User hat keine Quest akzeptiert
        //Zustand 2: User hat quest akzeptiert
        // Zustand 3 User hat quest hinter sich

        switch (QuestNPC.Rahl.QuestProgress)
        {
            case 0:
                Console.WriteLine("What do you want stanger. GET OUT OF MY WAY");
                break;
            case 1:
                Console.WriteLine(QuestNPC.Rahl.Name + ": What can I do for you, stranger. Want to test the sharpness of my sword?");
                Console.WriteLine();
                Console.ReadKey();

                // write your own text. Game will recognize KEywords and accept.
                Console.WriteLine(Game.UserAvatar.Name + ": Imartak send me out. You are training him some money. I am here to pick it up and give it imartak.");
                Console.WriteLine();
                Console.ReadKey();
                Console.WriteLine(QuestNPC.Rahl.Name + ": oh.... ");
                Console.WriteLine();
                Console.ReadKey();
                Console.WriteLine(QuestNPC.Rahl.Name + ": how boring, here... ");

                Game.UserAvatar.Money = 500;
                Console.WriteLine();
                Console.WriteLine("du erhälst: 500 Raash");
                Console.ReadKey();


                Console.WriteLine(QuestNPC.Rahl.Name + ": Get away, or I will slice you up.");

                QuestNPC.Rahl.QuestProgress = 2;
                break;
            case 2:
                Console.WriteLine("I have paid my dept, so screw you."); // rash müsste evtl verschwinden. 
                break;
        }
    }








    class Program

    {

        static Regex ChooseMenue = new Regex("^[1-5]$");
        static void Main()

        {
            Game.CreateCity();
            QuestNPC.CreateNPC();



            FirstMenue.FirstMenueChoose();

            // Game.StartGame();


            Console.Clear();
            // always get those options

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            int Counter = 0;
            while (Counter == 0)
            {
                Console.WriteLine(Game.UserAvatar.STATS);

                Console.WriteLine(Game.UserAvatar.CurrentCity.Name);

                Console.WriteLine(@"
                
                What do you want to do?

                1. Travel to another city
                2. Look arround
                3. Check my travelBag
                4. End Game
                5. Save Game
                6. DAS IST EIN GITHUB TEST
                ");



                int chooseOption = 0;

                while (!ChooseMenue.IsMatch(chooseOption.ToString()))
                {
                    try

                    {
                        Console.WriteLine("Please enter a number between the given options.");
                        chooseOption = Convert.ToInt32(Console.ReadLine());

                    }

                    catch
                    {
                        Console.WriteLine("Invalid.");
                    }

                }







                switch (chooseOption)
                {
                    case 1:
                        Console.Clear();
                        Game.nextCity();
                        break;
                    case 2:
                        Console.Clear();
                        Quest.StoryLine(Game.UserAvatar.CurrentCity);
                        break;
                    case 3:
                        Console.Clear();
                        TravelBag.show();
                        break;
                    case 4:
                        Console.Clear();
                        Environment.Exit(1);
                        break;
                    case 5:
                        Console.Clear();
                        SaveGame.SaveGameDATA();
                        break;
                }

            }
        }
    }
}


















