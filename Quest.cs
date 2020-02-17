using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Text.Adv.mit_Greg
{
    class Quest
    {
        public static int TarkrotThreat = 4;
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
                    Try3(QuestCity); 
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
                   
                   QuestNPC.ImartakQuest();
                }
            }
            else if (QuestCity2 == City.Bort)
            {
                if (Player.p.Level < 2)
                {
                    Console.Clear();
                    
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
                if (Player.p.Level == 2)
                {
                    QuestNPC.TarkrotQuest();
                }
            }


        }
        static void Try3(City QuestCity2)
        {
            if (QuestCity2 == City.Drana)
            {

                if (Player.p.Level < 2)
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
            if (QuestCity2 == City.Bort)
            {

                if (Player.p.Level < 2)
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
            if (QuestCity2 == City.TorVonHundrial)
            {

                if (Player.p.Level < 2)
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
                else if (Player.p.Level == 2)
                {
                    QuestNPC.BlackThornsQuest();

                }
            }
            
        }
    }
    public class QuestNPC
    {
        public string Name;
        public int QuestProgress;


        public static QuestNPC Imartak = new QuestNPC();
        public static QuestNPC Rahl = new QuestNPC();
        public static QuestNPC Tarkrot = new QuestNPC();
        

        public static void CreateNPC()
        {

            Imartak.Name = "old man";
            Imartak.QuestProgress = 0;

            Rahl.Name = "Rahl";
            Rahl.QuestProgress = 0;

            Tarkrot.Name = "Tarkrot";
            Tarkrot.QuestProgress = 0;



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


        // Quest description. You meet Tarkrot and his guys from the mercenary group "Black Thorn". If you are unpolite - he kills you. If you are polite, he invites you to help him as food for the Arrows of the enemie
        // You can't reject this quest. You have to follow the instructions and travel to Tor von Hundrial. There you will help him to fight some city guards. You´ll get some money and a hint
        // for the next Quest. If you ignore Tarkrots Thread and you travel 4 times without going to the Street of past wars in Tor von Hundrial he will find you and Kill you. 
        public static void BlackThornsQuest()
        {

            if (Tarkrot.QuestProgress == 0)
            {
                Console.WriteLine("Stranger: Hey you! Whats your name?");

                Console.WriteLine(Player.p.name + ":    1. who is asking?\n" +
                                                                     "         2. " + Player.p.name);


                int NOTHING = Convert.ToInt32(Console.ReadLine());
                if (NOTHING == 1)
                {
                    Console.WriteLine("Stranger : Excuse me... ");
                    Thread.Sleep(50);

                    Console.WriteLine("Stranger : AND I AM THE ONE WHO ASKS THE QUESTION!");
                    Console.ReadKey();
                    Console.WriteLine("Stranger: So again. What is your Name?");
                    Console.ReadKey();
                    Console.WriteLine("You notice that some other guys are watching this conversation ready to join. Something is telling you they all belong together...");
                    Console.ReadKey();

                    Console.WriteLine(Player.p.name + ":    1. Don't bother me...\n" +
                                                                     "         2. " + Player.p.name);

                    NOTHING = Convert.ToInt32(Console.ReadLine());
                    if (NOTHING == 1)
                    {
                        Class_Encouters.TarkrotEncounter(); // der Gedanke hier ist, dass Tarkrot zu stark ist. Tarkrot soll nicht sterben.

                    }

                }
                else if (NOTHING == 2)
                {
                    Console.WriteLine("Stranger :" + Player.p.name + "... ");
                    Console.ReadKey();
                    Console.WriteLine("Stranger: what a rediculous name * laughing *");
                    Console.ReadKey();
                    Console.WriteLine(QuestNPC.Tarkrot.Name + ": My Name is Tarkrot. And I am offering you an offer");


                }

                Console.WriteLine(QuestNPC.Tarkrot.Name + ": My friends and I are going to The City Tor von Hundrial. Our Client pays us to get rid of some people");
                Console.WriteLine(QuestNPC.Tarkrot.Name + ": WE ARE THE FAMOUS: Black Thorns and from time to time, we hire some rookies as food for the arrrows of the enemie * laughing *  ");
                Console.ReadKey();
                Console.WriteLine(QuestNPC.Tarkrot.Name + ": And for our entertainment");
                Console.ReadKey();
                Console.WriteLine(QuestNPC.Tarkrot.Name + ": So we see you there. Walk along the street and be aware of the city guards. Some of them are sneaky basterds");
                Console.WriteLine(QuestNPC.Tarkrot.Name + ": And don't try to fool me. If you don't appear, i'll come and get you!");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ReadKey();

                Console.WriteLine("Tarkrot and his friends from the Black Thorns are leaving the tavern. You can travel 4 times to find them before Tarkrot finds you.... ");
                Console.ReadKey();
                Tarkrot.QuestProgress = 1;
            }
            else if (Tarkrot.QuestProgress == 1)
            {
                Console.WriteLine("hier kommt die Methode für die Taverne ohne Quest");
            }




        }


        public static void TarkrotQuest()
        {
            
            Console.WriteLine("You walk along the " + City.TorVonHundrial.StreetsName + " in the City " + City.TorVonHundrial.Name + ".");
            Console.WriteLine("The city is known for the only easy path which leads to the Area "+ City.SaeIlaas.AreaWhereTheCityIs.Name + " & " + City.Metherwhere.Name + ".");
            Console.ReadKey();
            Console.WriteLine("While you walk towards the edge of the town....");
            Console.ReadKey();
            Console.WriteLine(QuestNPC.Tarkrot.Name + ": psssst.....");
            Console.ReadKey();
            Console.WriteLine(QuestNPC.Tarkrot.Name + " grabs you and drags you into an alley.");
            Console.WriteLine(QuestNPC.Tarkrot.Name + @": Listen close! I only tell you once. There will be a group of guards comming along this street.
                                                          They are probably be about 10. You will attack them all alone at once *laughing*
                                                          If you got all the attention, we will attack them from behind.");
            Console.ReadKey();
            Console.WriteLine(QuestNPC.Tarkrot.Name + @": GOT IT?");
            Console.ReadKey();
            Console.WriteLine(Player.p.name + @": 1. Yes. but watch out, otherwise everyone will be dead before you and your people have drawn your weapons
                                                 2. ... As if I have a choise");

            int ChooseAnswer = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Tarkrot leaves you alone. And you try to recognize those guards...");
            Console.ReadKey();
            Console.WriteLine("After a while there are some guards comming across the street.");
            Console.ReadKey();
            Console.WriteLine("You wait...");
            Console.ReadKey();
            Console.WriteLine("a little longer...");
            Console.ReadKey();
            Console.WriteLine("NOW!");

            Class_Encouters.GroupGuardEncouter();


            Console.WriteLine(QuestNPC.Tarkrot.Name + ": Show no merci!!!");
            Console.ReadKey();

            Console.WriteLine("Tarkrot and the black Thorns came out and kill the rest of the group. Fast and loud");
            Console.ReadKey();

            Console.WriteLine(QuestNPC.Tarkrot.Name + "Well done you little rookie. I remember good fighters. Take this money and get out of my way.");
            Console.ReadKey();
            QuestNPC.Tarkrot.QuestProgress = 3;
            Player.p.coins += 350;
            Console.WriteLine("Tarkrot gibt dir 350 Septime");
            Player.p.Level += 1;
            Console.WriteLine("Your Level: " + Player.p.Level);
            Console.ReadKey();


        }


    }
}
