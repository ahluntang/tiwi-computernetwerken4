using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using badminton;

namespace BadmintonTest
{
    class MaakDataBank
    {
        static void Main(string[] args)
        {
            ORMHelper.CreateDatabaseTables();
        }
    }
}
