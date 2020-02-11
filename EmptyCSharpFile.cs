using System;

public class Programm
{

    static Random rand = new Random();


  // public static string GegnerString
    //{
    
    

   // return gegner[0];
   // }

    public static void Main()
    {

        string[] gegner = { "Zombie", "Ritter", "Wache" };
        int randomInt = rand.Next(0, 2);

        Console.WriteLine(gegner[randomInt]);

        Console.WriteLine(gegner[randomInt]);
        Console.WriteLine(gegner[randomInt]); Console.WriteLine(gegner[randomInt]);
        Console.WriteLine(gegner[randomInt]);

    }
}