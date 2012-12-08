using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BadmintonInterface;

namespace BadmintonTest
{
    class TestBadmintonFabriek
    {
        BadmintonFabriek badmintonFabriek;
        public TestBadmintonFabriek()
        {
            badmintonFabriek = new badminton.ORMBadmintonFabriek();
        }
        static void Main(string[] args)
        {
            TestBadmintonFabriek test = new TestBadmintonFabriek();
            test.ToonSportClubs();
            test.ToonSportClubsMetTornooien();
            test.ToonLedenVanClub();
            test.ToonTornooien();
        }

        public void ToonSportClubs()
        {
            Console.WriteLine("Sportclubs");
            foreach (SportClub sportclub in badmintonFabriek.SportClubs)
            {
                Console.Write("ID:" + sportclub.ID);
                Console.WriteLine("; Naam:" + sportclub.Naam);
            }
        }

        public void ToonSportClubsMetTornooien()
        {
            Console.WriteLine("Sportclubs");
            foreach (SportClub sportclub in badmintonFabriek.SportClubs)
            {
                Console.Write("ID:" + sportclub.ID);
                Console.WriteLine("; Naam:" + sportclub.Naam);
                if (sportclub.Tornooien.Count > 0)
                {
                    Console.WriteLine("Tornooien");
                    foreach (Tornooi tornooi in sportclub.Tornooien)
                    {
                        Console.WriteLine(tornooi.ID + ": " + tornooi.Naam);
                    }
                }
                Console.WriteLine();
            }
        }

        public void ToonLedenVanClub()
        {
            Console.WriteLine("Geef id van club: ");
            string idString = Console.ReadLine();
            int id = int.Parse(idString);
            Console.WriteLine("Leden");
            foreach (Lid lid in badmintonFabriek.GeefLeden(id))
            {
                Console.WriteLine(lid.Naam);
            }
        }

        public void ToonTornooien()
        {
            Console.WriteLine("Tornooien");
            foreach (Tornooi tornooi in badmintonFabriek.Tornooien)
            {
                Console.WriteLine(tornooi.ID + ": " + tornooi.Naam);
            }
        }


    }

    
}
