using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OurSecrets
{
    public class DayAgenda
    {
        private List<Agenda> _agendaList;
        DateTime _dateTime;
        private Agendas _agendas;

        public DayAgenda(Agendas agendas, DateTime dateTime)
        {
            _agendas = agendas;
            _dateTime = dateTime;
            _agendas.PropertyChanged += NotifyPropertyChanged;
            _agendaList = _agendas.GetAgendaList(dateTime);
        }

        public int Count
        {
            get
            {
                return _agendaList.Count;
            }
        }

        public Agenda this[int key]
        {
            get
            {
                return _agendaList[key];
            }
        }

        protected void NotifyPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            _agendaList = _agendas.GetAgendaList(_dateTime);
        }
    }
}
