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

        
            Combat(false, "Rahl:", 15, 4, 4, Pics.titel2);

        }
        public static void TarkrotEncounter()
        {
            Console.WriteLine(Pics.titel9);


            Combat(false, "Tarkrot:", 35, 21, 15, Pics.titel9);

        }
        public static void BasicFightEncouter()
        {
            Console.Clear();
            Console.WriteLine("The next ");
            Console.ReadKey();
            Combat(true, "", 0, 0, 0, ""); // Werte des Gegners 
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
        public static void Combat(bool random, string name, int health, int power, int runspeed, string Titel)// Variablen werden deklariert 
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
            int CombatTurn = 0;
            while (h > 0)
            {
                


                Console.Clear();
                Console.WriteLine(Titel);


                if (CombatTurn == 1) // überprüfe ob Gegner dran ist. 
                {
                    CombatOpponent(false, n, p, h, r); // gegner macht entweder Angriff oder er heilt sich -> siehe ganz unten
                }
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
                    int damage = (p) - Player.p.armorValue;// verweis auf Program um sich den Werten des Spielers zu bedienen
                    if (damage < 0)
                    {
                        damage = 0;// kein negativ damage 
                    }
                    int attack = rand.Next(1, Player.p.weaponValue) + rand.Next(1, 4);

                    Console.WriteLine("Du verlierst " + damage + " Gesundheit und machst " + attack + " Schaden");

                    Player.p.health -= damage;

                    h -= attack;
                    CombatTurn = 1;

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

                    Console.WriteLine(" You lost" + damage + "  HP  but you deal  " + attack + "damage ");
                    Player.p.health -= damage;
                    h -= attack;
                    CombatTurn = 1;

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
                        Console.WriteLine("well done you have been faster" + n);
                        Quest.StoryLine(Player.p.CurrentCity);

                        //go to another pleace
                    }
                    else if (r > Player.p.runspeed)
                    {
                        Console.WriteLine(n + " is way faster than you, you got " + damage + " damaga ");

                    }
                    Player.p.health -= damage;
                    CombatTurn = 1;
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //Heal 
                    if (Player.p.potion == 0)
                    {
                        Console.WriteLine("You have no potions anymore ..rip");
                        CombatTurn = 1;
                    }
                    else
                    {
                        Console.WriteLine("You take a Healpotion");
                        int potionV = 5;
                        Console.WriteLine("You regenerate " + potionV + " health");
                        Player.p.health += potionV;
                        CombatTurn = 1;
                    }

                }
                else if (input == "") // hab mich mehrmals vertippt und dachte es wäre ganz nice bis wir regex anwenden
                {
                    Console.WriteLine("Please enter one of the given letters in brackets");
                }
                Console.ReadKey();
                if (Player.p.health <= 0)
                {
                    //Tod
                    Console.Clear();
                    Console.WriteLine(Player.p.name + " you are dead  " + n + " did kill you");
                    Console.ReadKey();
                    Console.Clear();
                  //  Console.WriteLine(Program.currentTexturen.titel3);
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }

            }



            int c = Player.p.GetCoins();

            Console.WriteLine(@" His body is covered in blood, do you want to search for some Items?                             ", 120);

            string input1 = Console.ReadLine();

            if (input1.ToLower() == "yes" || input1.ToLower() == "search")
            {
                Console.WriteLine("you disgrace his body you fund " + c + " Septime !");
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
                    return "guard";
                case 2:
                    return "Knight";
                case 3:
                    return "Prisoner";
                case 4:
                    return "Torture master ";
                case 5:
                    return "Magier";
                case 6:
                    return "Dog";
                case 7:
                    return "Bat";
                case 8:
                    return "Vampier";
                case 9:
                    return "Räuber";
                case 10:
                    return "Drache";

            }
            return "Schlange";

        }


        public static void CombatOpponent(bool random, string name, int health, int power, int runspeed)// Variablen werden deklariert

        {

           string n = name;
              int p = power;
              int h = health;
              int r = runspeed;
              int gesamtHP = health;




            int AttackOrHeal = rand.Next(1, 10); // wenn goesser gleich 5 dann wird angegriffen, wenn kleiner 4 heilt sich der Gegner

            if (AttackOrHeal >= 5) // attack
            {

                Console.WriteLine(n + "greift dich an.");

                int damage = rand.Next(1, Player.p.armorValue);
                if (damage < 0)
                {
                    damage = 0;// kein negativ damage 
                }
                else if (damage > h ) // kann sich durch selbstverletzen nicht selbst umbringen. eigener Schaden durch Angriff kann HP != 0 setzen
                {
                    damage = damage - (h / 2);
                }

                int attack = rand.Next(1, p) + rand.Next(1, 4); // es gibt kein weapon value... evtl nachCoden.

                Console.WriteLine(n + "verliert " + damage + " Gesundheit und fügt dir " + attack + " Schaden zu");
                Console.WriteLine();
                Console.ReadKey();

                Player.p.health -= attack;

                h -= damage;

            }
            else if (AttackOrHeal < 5) // heal
            {
                if (h >= (gesamtHP / 2))// wenn aktuelle HP > als die hälfte ist
                {
                    h += (gesamtHP / 4); // dann max 1/4 der urspruenglichen Hp healen
                    if (h > gesamtHP)
                    {
                        h = gesamtHP; // kann sich nicht mehr Heilen als ursprüngliche HealPoints
                    }

                } else if (h <= (gesamtHP / 2))
                {
                    h += (gesamtHP / 3); // wenn weniger als die hölfte, dann max + 1/3 von urspruenglicher Healpoints
                }


            }


        }

    }
}
