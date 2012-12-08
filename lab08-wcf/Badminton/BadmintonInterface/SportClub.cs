using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BadmintonInterface
{
    public interface SportClub
    {
        int ID { get; }
        String Naam { get; }
        IList<Tornooi> Tornooien { get; }
        IList<Lid> Leden { get; }

        void VoegTornooiToe(Tornooi tornooi);
        void VoegLidToe(Lid lid);
    }
}
