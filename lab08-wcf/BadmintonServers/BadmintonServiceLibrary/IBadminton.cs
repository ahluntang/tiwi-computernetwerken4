using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BadmintonInterface;

namespace BadmintonServiceLibrary
{
    [ServiceContract]
    public interface IBadminton
    {
        [OperationContract]
        List<SportClubType> GetAlleSportClubs();

        [OperationContract]
        List<LidType> GetLeden(SportClubType club);
    }


    [DataContract]
    public class SportClubType
    {
        int _ID = 0;
        String _Naam = "";
        IList<TornooiType> _Tornooien = null;
        IList<LidType> _Leden = null;


        [DataMember]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        [DataMember]
        public string Naam
        {
            get { return _Naam; }
            set { _Naam = value; }
        }

        [DataMember]
        public IList<LidType> Leden
        {
            get { return _Leden; }
            set { _Leden = value; }
        }

        [DataMember]
        public IList<TornooiType> Tornooien
        {
            get { return _Tornooien; }
            set { _Tornooien = value; }
        }
    }

    [DataContract]
    public class LidType
    {
        int _ID = 0;
        String _Naam = "";
        SportClubType _Club = null;


        [DataMember]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        [DataMember]
        public string Naam
        {
            get { return _Naam; }
            set { _Naam = value; }
        }


        [DataMember]
        public SportClubType Club
        {
            get { return _Club; }
            set { _Club = value; }
        }
    }



    [DataContract]
    public class TornooiType
    {
        int _ID;
        String _Naam;
        IList<SpelerType> _Deelnemers;
        SportClubType _Organisator;


        [DataMember]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        [DataMember]
        public string Naam
        {
            get { return _Naam; }
            set { _Naam = value; }
        }

        [DataMember]
        public IList<SpelerType> Deelnemers
        {
            get { return _Deelnemers; }
            set { _Deelnemers = value; }
        }


        [DataMember]
        public SportClubType Organisator
        {
            get { return _Organisator; }
            set { _Organisator = value; }
        }
    }


    [DataContract]
    public class SpelerType : LidType
    {

        String _Categorie;
        IList<TornooiType> _Tornooien;



        [DataMember]
        public string Categorie
        {
            get { return _Categorie; }
            set { _Categorie = value; }
        }


        [DataMember]
        public IList<TornooiType> Tornooien
        {
            get { return _Tornooien; }
            set { _Tornooien = value; }
        }
    }


}
