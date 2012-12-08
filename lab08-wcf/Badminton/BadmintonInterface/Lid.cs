using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BadmintonInterface
{
    public interface Lid
    {
        int ID { get; }
        String Naam { get; }
        SportClub Club { get; }
    }
}
