using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate; // ISessionFactory
using NHibernate.Cfg; // Configuration
using NHibernate.Mapping.Attributes; // HbmSerializer
using NHibernate.Tool.hbm2ddl; // SchemaExport

namespace badminton
{
    public class ORMHelper
    {
        private static readonly Configuration cfg;
        private static readonly ISessionFactory sessionFactory;

        static ORMHelper()
        {
            cfg = new Configuration();
            cfg.AddAssembly("badminton");
            cfg.Configure();
            
            HbmSerializer.Default.Validate = true; // Enable validation (optional)    
            // alle klassen serializeren
            cfg.AddInputStream(HbmSerializer.Default.Serialize(System.Reflection.Assembly.GetExecutingAssembly()));
            //cfg.AddInputStream(HbmSerializer.Default.Serialize(typeof(ORMLid).Assembly));
            
            sessionFactory = cfg.BuildSessionFactory();
        }

        public static void CreateDatabaseTables()
        {
            new SchemaExport(cfg).Create(false, true);
        }

        public static ISession OpenSession()
        {
            return sessionFactory.OpenSession();
        }
    }
}
