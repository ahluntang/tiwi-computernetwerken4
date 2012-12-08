using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BadmintonInterface
{
    public interface Speler : Lid
    {
        String Categorie { get; }
        IList<Tornooi> Tornooien { get; }

        void VoegTornooiToe(Tornooi tornooi);
    }
}
