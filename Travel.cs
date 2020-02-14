using System;
using System.Collections.Generic;
using System.Text;

namespace Text.Adv.mit_Greg
{
    class Travel
    {




        public static void nextCity()
        {

            Console.WriteLine(@"You are in the City: " + Player.p.CurrentCity.Name + " in " + Player.p.CurrentCity.AreaWhereTheCityIs.Name);

            



            int cheklength = Player.p.CurrentCity.nearCityLIST.Count;


            Console.WriteLine(@"You can travel to the City: ");

            for (int i = 0; i < cheklength; ++i)
            {
                Console.WriteLine(@"
                    
                                    " + (i + 1) + ")" + Player.p.CurrentCity.nearCityLIST[i].Name + " in " + Player.p.CurrentCity.nearCityLIST[i].AreaWhereTheCityIs.Name);
            }
            Console.WriteLine(@"Where you do you want to travel? ");

            int ChooseTravelOption = Convert.ToInt32(Console.ReadLine());

            switch (ChooseTravelOption)
            {
                case 1:
                    Player.p.CurrentCity = Player.p.CurrentCity.nearCityLIST[0];
                    break;
                case 2:
                    Player.p.CurrentCity = Player.p.CurrentCity.nearCityLIST[1];
                    break;
                case 3:
                    Player.p.CurrentCity = Player.p.CurrentCity.nearCityLIST[2];
                    break;
                case 4:
                    Player.p.CurrentCity = Player.p.CurrentCity.nearCityLIST[3];
                    break;
            }
           
            
            Console.WriteLine("You are now in: " + Player.p.CurrentCity.Name + " in " + Player.p.CurrentCity.AreaWhereTheCityIs.Name);
            Console.ReadKey();





        }
 
    }

    public class Area
    {
        public string Name;
        public string City;


    }
    public class City
    {
        public string Name;
        public Area AreaWhereTheCityIs;
        public List<City> nearCityLIST;


       
        public string StreetsName;
        public string TavernName;

        // public List<QuestNPC> StreetNPCList;
        //public List<QuestNPC> TavernNPCList;



        public static Area ForestOfRaash = new Area(), SpringOfNasmah = new Area(), Metherwhere = new Area();
        public static City Drana = new City(), Bort = new City(), TorVonHundrial = new City(), Ranador = new City(), Mandrial = new City(), SaeIlaas = new City(), Openworld = new City();
        
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


           // Drana.StreetNPCList = new List<QuestNPC>() { QuestNPC.Imartak };
            Drana.StreetsName = "street of fallen warrior";
            Drana.TavernName = "Boldly Bear";

           // Bort.StreetNPCList = new List<QuestNPC>() { QuestNPC.Rahl };
            Bort.StreetsName = "street of vengeful sinners";
            Bort.TavernName = "suicide silence";



          

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


    }

   












}
