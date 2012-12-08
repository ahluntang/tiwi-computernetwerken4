using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BadmintonInterface
{
    public interface BadmintonDAO
    {
        SportClub[] SportClubs { get; }
        Lid[] GeefLeden(int clubID);
        Tornooi[] Tornooien { get; }
    }
}
