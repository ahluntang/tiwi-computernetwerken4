using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BadmintonInterface;
using BadmintonORM;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.Attributes; // HbmSerializer

namespace BadmintonTest
{
    class VulDataBank
    {

        private readonly ISessionFactory sessionFactory;

        VulDataBank()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();

            HbmSerializer.Default.Validate = true; // Enable validation (optional)    
            // alle klassen serializeren van de assembly BadmintonORM
            cfg.AddInputStream(HbmSerializer.Default.Serialize(typeof(ORMLid).Assembly));

            sessionFactory = cfg.BuildSessionFactory();
        }
        static void Main(string[] args)
        {
            VulDataBank prog = new VulDataBank();
            prog.MaakSportClubs();
            prog.MaakLeden();
            prog.MaakTornooien();
        }

        void MaakSportClubs()
        {
            String[] clubs = {"EIKENLO","FLEE SHUTTLE","GABAD FV	","GENTSE BC vzw",
                                 "GERAARDSBERGEN BC FV","HOGE WAL BC FV","KLEIN PLUIMPJE FV",
                                 "KLUISBOS BC FV", "LANDEGEM BC FV"};
            ISession sessie = null;
            ITransaction transactie = null;
            try
            {
                sessie = sessionFactory.OpenSession();
                transactie = sessie.BeginTransaction();
                foreach (String club in clubs)
                {
                    SportClub sportclub = new ORMSportClub(club);
                    sessie.Save(sportclub);
                }
                transactie.Commit();
            }
            catch (Exception e)
            {
                if (transactie != null)
                    transactie.Rollback();
                Console.WriteLine("Fout bij bewaren sportclub:" + e.Message);
            }
            finally
            {
                if (sessie != null)
                {
                    sessie.Close();
                }
            }            
        }

        void MaakLeden()
        {
            String[] leden = {"THYS AN","LIEVENS YVETTE","GEYSEN ELLEN","VAN DEN BUSSCHE JOERI",
                                 "VANTHOURNOUT PIET", "DOSSCHE MARIO","VAN AELST KAREN", 
                                 "HULSTAERT JOHAN","DE WAELE GERT","YDENS DANNIE","WEYN FRANKY",
                                 "DE BRUYN WALTER","DE VOS GEORGES","RUYS LEO","DE VISSCHERE PATRICK",
                                 "DE BOLLE DAVID","VAN DER VORST FONS","SMEKENS ANN"};
            String[] spelers = {"DE VLIEGER JEAN PIERRE","DE MUER LANDER","DE SMET NANCY",
                                 "GOVAERTS PATRICK","MONS THOMAS","DE WISPELAERE ANDRE",
                                 "DE SCHRYVER GAETAN","VANHAESEBROECK WIM","VAN DAMME HERMAN",
                                 "VAN DER STRICHT STEPHANIE","VAN BOUWEL GERT","WILLEMS CARLOS",
                                 "VLAMIJNCK YVES","VAN HOVE MARJOLIJN","VAN HOOSTE LIEVEN",
                                 "VAN DELSEN WILLY","PIQUEUR GERT","VERMEULEN ANNIE	","VAN HOEYMISSEN TOM",
                                 "REYNAERT NANCY","VERMEERSCH RINO","VAN DER AA MARC","CAUWELS KATRIEN",
                                 "BRACKE EVY","BAECKELAND ERIC","WYFFELS JOWAN","MERCKX MIREILLE",
                                 "ROELANTS TOM","IMSCHOOT JORIS","VAN DE GEHUCHTE JULIE",
                                 "VANDENHOUCKE JORIS","DE VIDTS BJORN"};
            String[] categorie = { "A", "B1", "B2", "C1", "C2", "D" };
            ISession sessie = null;
            ITransaction transactie = null;
            try
            {
                sessie = sessionFactory.OpenSession();
                transactie = sessie.BeginTransaction();
                ICriteria filter = sessie.CreateCriteria(typeof(ORMSportClub));
                IList<SportClub> clubs = filter.List<SportClub>();
                // leden toevoegen
                int teller = 0;
                foreach (String naam in leden)
                {
                    ORMLid lid = new ORMLid();
                    lid.Naam = naam;
                    lid.Club = clubs[teller];
                    teller++;
                    if (teller == clubs.Count)
                        teller = 0;
                    sessie.Save(lid);
                }
                // spelers toevoegen
                teller = 0;
                Random willekeurigGetal = new Random();
                foreach (String naam in spelers)
                {
                    ORMSpeler speler = new ORMSpeler();
                    speler.Naam = naam;
                    speler.Club = clubs[teller];
                    teller++;
                    if (teller == clubs.Count)
                        teller = 0;
                    int index = willekeurigGetal.Next(5);
                    speler.Categorie = categorie[index];
                    sessie.Save(speler);
                }
                transactie.Commit();
            }
            catch (Exception e)
            {
                if (transactie != null)
                    transactie.Rollback();
                Console.WriteLine("Fout bij bewaren sportclub:" + e.Message);
            }
            finally
            {
                if (sessie != null)
                {
                    sessie.Close();
                }
            }
        }

        void MaakTornooien()
        {
            String[] namen = {"Finaledag FUTURE NATIONS CUP 21","Pluimplukkers recreantentornooi",
                                "Vlaams Kampioenschap"};
            ISession sessie = null;
            ITransaction transactie = null;
            try
            {
                sessie = sessionFactory.OpenSession();
                transactie = sessie.BeginTransaction();
                ICriteria filterClubs = sessie.CreateCriteria(typeof(ORMSportClub));
                IList<SportClub> clubs = filterClubs.List<SportClub>();
                ICriteria filterSpelers = sessie.CreateCriteria(typeof(ORMSpeler));
                IList<Speler> spelers = filterSpelers.List<Speler>();
                Random willekeurigGetal = new Random();
                foreach(String naam in namen) {
                    ORMTornooi tornooi = new ORMTornooi();
                    tornooi.Naam = naam;
                    tornooi.Organisator = clubs[willekeurigGetal.Next()%clubs.Count];
                    for (int i = 0; i < 5; i++)
                    {
                        Speler speler = spelers[willekeurigGetal.Next()%spelers.Count];
                        if (tornooi.Deelnemers == null || !tornooi.Deelnemers.Contains(speler))
                            tornooi.VoegSpelerToe(speler);
                    }
                    sessie.Save(tornooi);
                }

                transactie.Commit();
            }
            catch (Exception e)
            {
                if (transactie != null)
                    transactie.Rollback();
                Console.WriteLine("Fout bij bewaren sportclub:" + e.Message);
            }
            finally
            {
                if (sessie != null)
                {
                    sessie.Close();
                }
            }
        }
    }
}
