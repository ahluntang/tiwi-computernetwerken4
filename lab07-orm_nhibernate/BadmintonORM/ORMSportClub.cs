using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BadmintonInterface;
using NHMA = NHibernate.Mapping.Attributes;

namespace badminton
{
    [NHMA.Class(Table = "SportClubs")]
    public class ORMSportClub : SportClub
    {

        public ORMSportClub() { }

        public ORMSportClub(String naam)
        {
            Naam = naam;
        }

        private int id;
        [NHMA.Id(Name = "ID")]
        [NHMA.Generator(1, Class = "native")]
        public virtual int ID { get { return id; } set { id = value; } }

        [NHMA.Property]
        public virtual string Naam { get; set; }

        [NHMA.Bag(Lazy = false)]
        [NHMA.Key(1, Column = "SportClubID")]
        [NHMA.OneToMany(3,ClassType=typeof(ORMTornooi))]
        public virtual IList<Tornooi> Tornooien { get; set; }

        [NHMA.Bag] 
        [NHMA.Key(1, Column = "SportClubID")]
        [NHMA.OneToMany(2, ClassType = typeof(ORMLid))]
        public virtual IList<Lid> Leden { get; set; }

        public virtual void VoegTornooiToe(Tornooi tornooi)
        {
            if (Tornooien == null)
            {
                Tornooien = new List<Tornooi>();
            }
            Tornooien.Add(tornooi);
        }

        public virtual void VoegLidToe(Lid lid)
        {
            if (Leden == null)
            {
                Leden = new List<Lid>();
            }
            Leden.Add(lid);
        }
    }
}
