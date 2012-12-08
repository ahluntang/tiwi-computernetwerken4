using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BadmintonClientConsole.BadmintonServiceReference;
namespace BadmintonClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IBadminton client = new BadmintonClient();
            SportClubType[] sportclubs = client.GetAlleSportClubs();
            foreach (SportClubType sportclub in sportclubs)
            {
                Console.WriteLine("ID: " + sportclub.ID);
                Console.WriteLine("Naam: " + sportclub.Naam);
                Console.WriteLine("-----------------");
            }
            String id;
            id = Console.ReadLine();
            while (id != "") {
                SportClubType club = new SportClubType();
                club.ID = Convert.ToInt32(id);
                LidType[] leden = client.GetLeden(club);
                Console.WriteLine("Leden:");
                foreach (LidType lid in leden)
                {
                    Console.WriteLine("Naam: " + lid.Naam);
                }
                id = Console.ReadLine();
            }
        }
    }
}
