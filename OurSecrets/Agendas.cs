using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurSecrets
{
    public class Agendas
    {
        private static int _newAgendaID;
        public static int GetNewAgendaID()
        {
            return _newAgendaID++;
        }
    }
}
