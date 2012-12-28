using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurSecrets
{
    public class DayAgenda
    {
        private List<Agenda> _agendaList;

        public DayAgenda()
        {
            _agendaList = new List<Agenda>();
        }

        public DayAgenda(List<Agenda> agendaList)
            : this()
        {
            foreach (Agenda agenda in agendaList)
            {
                _agendaList.Add(agenda);
            }
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

        public Agenda this[int key]
        {
            get
            {
                return _agendaList[key];
            }
        }

        public void RemoveAgenda(Agenda agenda)
        {
            _agendaList.Remove(agenda);
        }
    }
}
