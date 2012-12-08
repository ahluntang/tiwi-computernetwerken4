using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BadmintonInterface;
using NHMA = NHibernate.Mapping.Attributes;

namespace BadmintonORM
{
    [NHMA.JoinedSubclass(ExtendsType=typeof(ORMLid),Table="Spelers")]
    public class ORMSpeler : ORMLid, Speler
    {
        [NHMA.Key(Column="ID")]
        [NHMA.Property]
        public virtual String Categorie { get; set; }

        [NHMA.Bag(Table="SpelersPerTornooi")]
        [NHMA.Key(1, Column = "SpelerID")]
        [NHMA.ManyToMany(2,ClassType=typeof(ORMTornooi),Column="TornooiID")]
        public virtual IList<Tornooi> Tornooien { get; set; }

        public virtual void VoegTornooiToe(Tornooi tornooi)
        {
            if (Tornooien == null)
            {
                Tornooien = new List<Tornooi>();
            }
            Tornooien.Add(tornooi);
        }
    }
}
