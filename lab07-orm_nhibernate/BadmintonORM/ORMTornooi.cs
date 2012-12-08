using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BadmintonInterface;
using NHMA = NHibernate.Mapping.Attributes;

namespace badminton
{
    [NHMA.Class(Table="Tornooien")]
    public class ORMTornooi : Tornooi
    {
        public ORMTornooi() { }

        public ORMTornooi(SportClub organisator)
        {
            Organisator = organisator;
        }

        private int id;
        [NHMA.Id(Name = "ID")]
        [NHMA.Generator(1, Class = "native")]
        public virtual int ID { get { return id; } set { id = value; } }

        [NHMA.Property]
        public virtual string Naam { get; set; }

        [NHMA.Bag(Table = "SpelersPerTornooi",Lazy=true)]
        [NHMA.Key(1, Column = "TornooiID")]
        [NHMA.ManyToMany(2, ClassType = typeof(ORMSpeler), Column = "SpelerID")]
        public virtual IList<Speler> Deelnemers { get; set; }

        [NHMA.ManyToOne(Column="SportClubID", ClassType=typeof(ORMSportClub))]
        public virtual SportClub Organisator { get; set; }

        public virtual void VoegSpelerToe(Speler speler)
        {
            if (Deelnemers == null) {
                Deelnemers = new List<Speler>();
            }
            Deelnemers.Add(speler);
        }
    }
}
