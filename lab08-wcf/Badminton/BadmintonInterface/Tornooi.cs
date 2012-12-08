using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BadmintonInterface
{
    public interface Tornooi
    {

        int ID { get; }
        String Naam { get; }
        IList<Speler> Deelnemers { get; }
        SportClub Organisator { get; }

        void VoegSpelerToe(Speler speler);
    }
}
