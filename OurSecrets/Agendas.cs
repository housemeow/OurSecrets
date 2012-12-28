using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurSecrets
{
    public class Agendas
    {
        private List<Agenda> _agendaList;

        private static int _newAgendaID;
        public static int GetNewAgendaID()
        {
            return _newAgendaID++;
        }

        public Agendas()
        {
            _agendaList = new List<Agenda>();
        }

        public int Count
        {
            get
            {
                return _agendaList.Count;
            }
        }

        public void AddAgenda(Agenda agenda)
        {
            _agendaList.Add(agenda);
        }

        public List<Agenda> GetAgendaList(DateTime? dateTime)
        {
            List<Agenda> resultAgenda = new List<Agenda>();
            foreach (Agenda agenda in _agendaList)
            {
                if (dateTime == null ^ agenda.StartDateTime == null)
                {
                    continue;
                }
                else if (agenda.StartDateTime <= dateTime && agenda.EndDateTime >= dateTime)
                {
                    resultAgenda.Add(agenda);
                }
            }
            return resultAgenda;
        }

        public List<Agenda> GetAgendaList(DateTime startDateTime, DateTime endDateTime)
        {
            List<Agenda> resultAgenda = new List<Agenda>();
            foreach (Agenda agenda in _agendaList)
            {
                if (startDateTime == null ^ agenda.StartDateTime == null)
                {
                    continue;
                }

                else if (startDateTime >= agenda.StartDateTime && agenda.StartDateTime <= endDateTime)
                {
                    resultAgenda.Add(agenda);
                }
                else if (startDateTime >= agenda.EndDateTime && agenda.EndDateTime <= endDateTime)
                {
                    resultAgenda.Add(agenda);
                }
            }
            return resultAgenda;
        }
    }
}
