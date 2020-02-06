using System;
using System.Collections.Generic;
using System.Text;

namespace Text.Adv.mit_Greg
{
    public class Class_Encouters
    {
        static Random rand = new Random();
        // Encouter Gereric
        //Encouters
        public static void RahlEncouter()
        {
            Console.WriteLine(Pics.titel2);

        
            Combat(false, "Rahl:", 15, 4, 4);

        }
        public static void BasicFightEncouter()
        {
            Console.Clear();
            Console.WriteLine("Der nächste Gegner wartet");
            Console.ReadKey();
            Combat(true, "", 0, 0, 0); // Werte des Gegners 
        }

        //Encouter Tool 
        public static void Print(string text, int speed = 40)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            Console.WriteLine();
        }
        public static void RandomEncouter()
        {
            switch (rand.Next(0, 1))
            {
                case 0:
                    BasicFightEncouter();
                    break;
            }

        }
        public static void Combat(bool random, string name, int health, int power, int runspeed)// Variablen werden deklariert 
        {
            string n = "";
            int p = 0;
            int h = 0;
            int r = 0;
            if (random)
            {
                n = GetName();// get name wird aufgerufen für die Monster
                p = rand.Next(1, 5);
                h = rand.Next(1, 8);
                r = rand.Next(1, 7);
            }

            else
            {
                n = name;
                p = power;
                h = health;
                r = runspeed;
            }

            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(Pics.titel2);
                Console.WriteLine("*                             *");
                Console.WriteLine(n);
                Console.WriteLine("Power " + p + " / " + h + "/Gesundheit " + r + " Schnellichkeit");
                Console.WriteLine("*                             *");
                Console.WriteLine(
    "<><><><><><><><><><><><><><>\n" +
    "<>========================<>\n" +
    "<>|(A)Angreifen  (D)efend|<>\n" +
    "<>|                      |<>\n" +
    "<>|(R)ennen      (H)eilen|<>\n" +
    "<>========================<>\n" +
    "<><><><><><><><><><><><><><>");

                Console.WriteLine("             Heiltränke:" + Player.p.potion + "  Gesundheit:" + Player.p.health);

                string input = Console.ReadLine();

                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    Console.WriteLine("Du greifst an, " + n + " erwischt dich beim Gegenschlag");
                    int damage = (p) -Player.p.armorValue;// verweis auf Program um sich den Werten des Spielers zu bedienen
                    if (damage < 0)
                    {
                        damage = 0;// kein negativ damage 
                    }
                    int attack = rand.Next(1, Player.p.weaponValue) + rand.Next(1, 4);

                    Console.WriteLine("Du verlierst " + damage + " Gesundheit und machst " + attack + " Schaden");

                  Player.p.health -= damage;

                    h -= attack;

                }

                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //defend 
                    Console.WriteLine("Du Verteidigst dich ");
                    int damage = p / 4 - Player.p.armorValue;
                    if (damage < 0)// damit kein negativ damage entsteht 
                    {
                        damage = 0;
                    }
                    int attack = rand.Next(1, Player.p.weaponValue) / 2;

                    Console.WriteLine("Du verlierst " + damage + " Gesundheit und machst " + attack + "Schaden");
                    Player.p.health -= damage;
                    h -= attack;

                }
                else if (input.ToLower() == "r" || input.ToLower() == "Run")
                {
                    //run 
                    int damage = (p * 5) - Player.p.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }

                    if (r < Player.p.runspeed)
                    {
                        Console.WriteLine("Du bist entkommen du bewegst dich schneller als" + n);
                        Quest.StoryLine(Player.p.CurrentCity);

                        //go to another pleace
                    }
                    else if (r > Player.p.runspeed)
                    {
                        Console.WriteLine(n + " war schneeler wie du!! du bekommst " + damage + " schaden");

                    }
                   Player.p.health -= damage;

                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //Heal 
                    if (Player.p.potion == 0)
                    {
                        Console.WriteLine("Du hast keine Tränke mehr..rip");

                    }
                    else
                    {
                        Console.WriteLine("Du trinkst einen Heiltrank");
                        int potionV = 5;
                        Console.WriteLine("Du regenerierst " + potionV + " Gesundheit");
                       Player.p.health += potionV;
                    }

                }
                Console.ReadKey();
                if (Player.p.health <= 0)
                {
                    //Tod
                    Console.Clear();
                    Console.WriteLine(Player.p.name + " you are dead  " + n + " hat dich besiegt");
                    Console.ReadKey();
                    Console.Clear();
                  //  Console.WriteLine(Program.currentTexturen.titel3);
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }

            }



            int c = Player.p.GetCoins();

            Console.WriteLine(@"                               Du hast ihr besiegt der Körper liegt unter dir, deine Fäust 
                               glühen und sind benetzt von Blut willst du schnell weiter oder
                               den leblosen Körper durchsuchen?", 120);

            string input1 = Console.ReadLine();

            if (input1.ToLower() == "ja" || input1.ToLower() == "durchsuchen")
            {
                Console.WriteLine("Du durchwühlst den leblosen Körper und findest " + c + " Münzen!");
                Player.p.coins += c;
            }

            else
            {
            }
             Player.p.coins += c;
            Console.ReadKey();
        }


        public static string GetName()// Gegner Ausnahme. 
        {
            switch (rand.Next(0, 10))
            {
                case 0:
                    return "Zombie";
                case 1:
                    return "Wache";
                case 2:
                    return "Ritter";
                case 3:
                    return "Gefangener";
                case 4:
                    return "Foltermeister";
                case 5:
                    return "Magier";
                case 6:
                    return "Hund";
                case 7:
                    return "Fledermaus";
                case 8:
                    return "Vampier";
                case 9:
                    return "Räuber";
                case 10:
                    return "Drache";

            }
            return "Schlange";

        }

    }
}
