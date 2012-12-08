using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BadmintonORM;
using BadmintonInterface;

namespace BadmintonServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Badminton : IBadminton
    {

        public List<SportClubType> GetAlleSportClubs()
        {
            ORMBadmintonDAO badmintonDAO = new ORMBadmintonDAO();
            List<SportClubType> sportclubs = new List<SportClubType>();

            foreach (SportClub sportclub in badmintonDAO.SportClubs)
            {
                SportClubType clubtype = new SportClubType();
                clubtype.ID = sportclub.ID;
                clubtype.Naam = sportclub.Naam;
                List<LidType> leden = new List<LidType>();
                /*foreach (Lid lid in clubtype.Leden) {
                    LidType lidtype = new LidType();
                    lidtype.ID = lid.ID;
                    lidtype.Naam = lid.Naam;
                    leden.Add(lidtype);
                }*/
                clubtype.Leden = leden;
                sportclubs.Add(clubtype);
            }

            return sportclubs;
        }

        public List<LidType> GetLeden(SportClubType club)
        {
            ORMBadmintonDAO badmintonDAO = new ORMBadmintonDAO();
            List<LidType> leden = new List<LidType>();

            foreach (Lid lid in badmintonDAO.GeefLeden(club.ID))
            {
                LidType lidtype = new LidType();
                lidtype.ID = lid.ID;
                lidtype.Naam = lid.Naam;
                lidtype.Club = club;
                leden.Add(lidtype);
            }

            return leden;
        }

    }
}
