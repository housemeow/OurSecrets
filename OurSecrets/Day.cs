using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurSecrets
{
    public class Day
    {
        private List<Agenda> _agendaList;

        public Day()
        {
            _agendaList = new List<Agenda>();
        }

        public Day(List<Agenda> agendaList)
        {
            _agendaList = new List<Agenda>();
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
