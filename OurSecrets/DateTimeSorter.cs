using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurSecrets
{
    public class DateTimeSorter:AgendaSorter
    {
        public override List<Agenda> Sort(List<Agenda> agendaList)
        {
            List<Agenda> sortedAgendaList = agendaList.OrderBy(o => o.StartDateTime).ToList();
            return sortedAgendaList;
        }
    }
}
