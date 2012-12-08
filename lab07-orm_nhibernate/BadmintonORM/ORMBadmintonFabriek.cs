using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BadmintonInterface;
using NHibernate;
using NHibernate.Criterion;

namespace badminton
{
    public class ORMBadmintonFabriek: BadmintonFabriek
    {
        public SportClub[] SportClubs {
            get
            {
                using (ISession sessie = ORMHelper.OpenSession())
                {
                    ICriteria filter = sessie.CreateCriteria(typeof(ORMSportClub));
                    IList<SportClub> clubs = filter.List<SportClub>();
                    return clubs.ToArray<SportClub>();
                }

            }
        }

        public Lid[] GeefLeden(int clubID)
        {
            using (ISession sessie = ORMHelper.OpenSession())
            {
                ICriteria filter = sessie.CreateCriteria(typeof(ORMLid))
                    .CreateAlias("Club", "Club").Add(Expression.Eq("Club.ID",clubID));
                IList<Lid> leden = filter.List<Lid>();
                return leden.ToArray<Lid>();
            }
        }

        public Tornooi[] Tornooien {
            get
            {
                using (ISession sessie = ORMHelper.OpenSession())
                {
                    ICriteria filter = sessie.CreateCriteria(typeof(ORMTornooi));
                    IList<Tornooi> clubs = filter.List<Tornooi>();
                    return clubs.ToArray<Tornooi>();
                }
            }
        }
    }
}
