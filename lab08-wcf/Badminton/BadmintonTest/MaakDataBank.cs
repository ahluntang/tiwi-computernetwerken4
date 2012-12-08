using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BadmintonORM;

namespace BadmintonTest
{
    class MaakDataBank
    {
        static void Main(string[] args)
        {
            new ORMBadmintonDAO().CreateDatabaseTables();
        }
    }
}
