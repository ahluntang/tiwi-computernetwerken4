using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BadmintonInterface;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Cfg; // Configuration
using NHibernate.Mapping.Attributes; // HbmSerializer
using NHibernate.Tool.hbm2ddl; // SchemaExport

namespace BadmintonORM
{
    public class ORMBadmintonDAO: BadmintonDAO
    {
        private readonly Configuration cfg;
        private readonly ISessionFactory sessionFactory;

        public ORMBadmintonDAO()
        {
            cfg = new Configuration();
            cfg.Configure();

            HbmSerializer.Default.Validate = true; // Enable validation (optional)    
            // alle klassen serializeren
            //cfg.AddInputStream(HbmSerializer.Default.Serialize(System.Reflection.Assembly.GetExecutingAssembly()));
            cfg.AddInputStream(HbmSerializer.Default.Serialize(typeof(ORMLid).Assembly));

            sessionFactory = cfg.BuildSessionFactory();
        }

        public SportClub[] SportClubs {
            get
            {
                using (ISession sessie = sessionFactory.OpenSession())
                {
                    ICriteria filter = sessie.CreateCriteria(typeof(ORMSportClub));
                    IList<SportClub> clubs = filter.List<SportClub>();
                    return clubs.ToArray<SportClub>();
                }

            }
        }

        public Lid[] GeefLeden(int clubID)
        {
            using (ISession sessie = sessionFactory.OpenSession())
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
                using (ISession sessie = sessionFactory.OpenSession())
                {
                    ICriteria filter = sessie.CreateCriteria(typeof(ORMTornooi));
                    IList<Tornooi> clubs = filter.List<Tornooi>();
                    return clubs.ToArray<Tornooi>();
                }
            }
        }

        public void CreateDatabaseTables()
        {
            new SchemaExport(cfg).Create(false, true);
        }
    }
}
