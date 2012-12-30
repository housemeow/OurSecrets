using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurSecrets
{
    public class AgendaSorter
    {
        public virtual List<Agenda> Sort(List<Agenda> agendaList)
        {
            List<Agenda> sortedAgendaList  = new List<Agenda>();
            foreach (Agenda agenda in agendaList)
            {
                sortedAgendaList.Add(agenda);
            }
            return sortedAgendaList;
        }
    }
}
























