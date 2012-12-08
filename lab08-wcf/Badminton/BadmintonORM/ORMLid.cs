using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BadmintonInterface;
using NHMA = NHibernate.Mapping.Attributes;

namespace BadmintonORM
{
    [NHMA.Class(Table="Leden")]
    public class ORMLid : Lid
    {

        private int id;
        [NHMA.Id(Name="ID")]
        [NHMA.Generator(1,Class="native")]
        public virtual int ID { get { return id; } set { id = value; } }
        [NHMA.Property]
        public virtual String Naam { get; set; }
        [NHMA.ManyToOne(Column="SportClubID",ClassType=typeof(ORMSportClub))]
        public virtual SportClub Club { get; set; }
    }
}
