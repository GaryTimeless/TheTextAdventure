using System;
using System.Collections.Generic;
using System.Text;

namespace Text.Adv.mit_Greg
{
    class Quest
    {

        public static void StoryLine(City QuestCity)
        {
            while (true)
            {
                Console.WriteLine("In " + Player.p.CurrentCity.Name + " you can:");

                Console.WriteLine(" (W)alk along the " + Player.p.CurrentCity.StreetsName);
                Console.WriteLine(" (C)heck out the tavern: " + Player.p.CurrentCity.TavernName);
                Console.WriteLine(" (G)o for shoping");
                Console.WriteLine(" (B)ack to mainmenu ");

                string input = Console.ReadLine();

                if (input.ToLower() == "g" || input.ToLower() == "go")
                {
                    Try1();
                }
                if (input.ToLower() == "w" || input.ToLower() == "walk")
                {
                    Try2(QuestCity);
                }
                if (input.ToLower() == "c" || input.ToLower() == "check")
                {
                    Try3(); 
                }
                if (input.ToLower() == "b" || input.ToLower() == "back")
                {
                    break;
                }

            }
        }
        static void Try1()
        {
            Shop.LoadShop(Player.p);
        }
        static void Try2(City QuestCity2)
        {
            if (QuestCity2 == City.Drana)
            {
                if (Player.p.Level < 2)
                {
                    Console.Clear();
                    // Class_Encouters.RahlEncouter();
                   QuestNPC.ImartakQuest();
                }
            }
            else if (QuestCity2 == City.Bort)
            {
                if (Player.p.Level < 2)
                {
                    Console.Clear();
                    // Class_Encouters.RahlEncouter();
                    QuestNPC.RahlQuest();
                }
            }
            else if (QuestCity2 == City.TorVonHundrial)
            {
                if (Player.p.Level > 1)
                {
                    Console.Clear();
                    Class_Encouters.BasicFightEncouter();
                }
            }


        }
        static void Try3()
        {
            Console.WriteLine("  As you approach the building, you notice the smell of alcohol, something to eat,\n"
                              + "         and a mixture of blood and sweat. There is a sign on the outside. Tavern: bold bear.\n" +
                              "          The tavern appears to be an old building. It is damaged in many places. \n" +
                              "          In detail, however,there are some elements typical of Septime. \n" +
                              "          The basic structure is made of Septimetan wood. The walls made of clay and stones \n" +
                              "          and the windows angular without glass. The characters in the beam of the house \n" +
                              "          that the roof supports are striking. STRONG BODY, STRONG MIND, NO MERCY. \n" +
                              "          But the tavern is closed... ");
            Console.ReadKey();
            Console.Clear();
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

        public static void ImartakQuest()
        {


            switch (QuestNPC.Imartak.QuestProgress)
            {
                case 0:
                    {
                        Console.WriteLine("You see an " + QuestNPC.Imartak.Name + " near a a fountain.\n" +
                                          "As you come closer the man pays you attention and smiled in greeting.");
                        Console.WriteLine();
                        Console.WriteLine(QuestNPC.Imartak.Name + ": You have that look of someone who is here for the first time.\n" +
                                                          "         And all people comming here are looking for the same two things.\n" +
                                                          "         MONEY or HONOR - mostly both.\n" +

                                                          "         What are you looking for?");

                        Console.WriteLine();
                        Console.WriteLine(Player.p.name + ":    1. Money\n" +
                                                                 "         2. Honor");


                        int NOTHING = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine();
                        Console.WriteLine(QuestNPC.Imartak.Name + ": Like I said. With honor I can not help you, it is best\n " +
                                                          "        to go to the bear. \n" +
                                                          "         But I'm ready to give you some money if you do me a favor.");


                        Console.WriteLine();
                        Console.WriteLine(Player.p.name + ":    1. Okay, but what is the deal?\n" +
                                                          "         2. Hm.. maybe another time. Money is no important right now");



                        int MoneyOrHonor = Convert.ToInt32(Console.ReadLine());

                        if (MoneyOrHonor == 1)

                        {
                            Console.WriteLine(QuestNPC.Imartak.Name + ": The deal is that you have to travel to Bort.\n" + "" +
                                                           "         You should find a middle-aged man on the streets\n" + "" +
                                                           "         who is an old friend of mine.\n"+
                                                           "         He still trains me money. I need at least 500 Septime. \n" +
                                                           "         Tell him Imartak sends you. \n" +
                                                           "         I´ll give you 200 Septime for delivering. Do you help me out?") ;





                            Console.WriteLine();
                            Console.WriteLine(Player.p.name + ":    1. Yes, that should be easy!\n" +
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
                    if (Player.p.coins >= 500)
                    {
                        Console.WriteLine(QuestNPC.Imartak.Name + @": YES, Thank you! Keep the 200");
                        Console.ReadKey();
                        Player.p.coins -= 300;
                        QuestNPC.Rahl.QuestProgress = 2;
                        QuestNPC.Imartak.QuestProgress = 2;

                        Console.WriteLine("You give Imartak the money");
                        Console.ReadKey();
                        Player.p.Level++ 
                            ;
                        Console.WriteLine("Your Level increase: " + Player.p.Level);
                        Console.ReadKey();
                        Console.Clear();



                    }
                    else 
                    {
                        Console.ReadKey();
                        Console.WriteLine("Unfortunately you don't have enough money");
                        Console.WriteLine();
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
                    Console.WriteLine(Player.p.name + ": Imartak send me out. You are training him some money. I am here to pick it up and give it imartak.");
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.WriteLine(QuestNPC.Rahl.Name + ": oh.... ");
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.WriteLine(QuestNPC.Rahl.Name + ": well finally someone to mess with, here... we go ");
                    Console.ReadKey();

                    Class_Encouters.RahlEncouter();

                    Player.p.coins += 500;
                    Console.WriteLine();
                    Console.WriteLine("du erhälst: 500 Septime");
                    Console.ReadKey();
                    Console.Clear();

                    QuestNPC.Rahl.QuestProgress = 2;
                    break;
                case 2:
                    Console.WriteLine("I have paid my dept, so screw you."); // rash müsste evtl verschwinden. 
                    break;
            }
        }


    }
}
