using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OurSecrets
{
    public class Agendas : INotifyPropertyChanged
    {
        private List<Agenda> _agendaList;
        public event PropertyChangedEventHandler PropertyChanged;

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

                else if (startDateTime <= agenda.StartDateTime && agenda.StartDateTime <= endDateTime)
                {
                    resultAgenda.Add(agenda);
                }
                else if (startDateTime <= agenda.EndDateTime && agenda.EndDateTime <= endDateTime)
                {
                    resultAgenda.Add(agenda);
                }
            }
            return resultAgenda;
        }

        public void AddAgenda(Agenda agenda)
        {
            _agendaList.Add(agenda);
            agenda.PropertyChanged += NotifyPropertyChanged;
            NotifyPropertyChanged(agenda, new PropertyChangedEventArgs("AddAgenda"));
        }

        public void RemoveAgenda(Agenda agenda)
        {
            agenda.PropertyChanged -= NotifyPropertyChanged;
            _agendaList.Remove(agenda);
            NotifyPropertyChanged(agenda, new PropertyChangedEventArgs("RemoveAgenda"));
        }

        public List<DayAgenda> GetDayList(DateTime startDateTime, DateTime endDateTime)
        {
            List<DayAgenda> dayList = new List<DayAgenda>();
            DateTime dateTime = startDateTime;
            for (; dateTime <= endDateTime; dateTime = dateTime.AddDays(1))
            {
                DayAgenda day = new DayAgenda(this, dateTime);
                dayList.Add(day);
            }
            return dayList;
        }

        public DayAgenda GetDay(DateTime dateTime)
        {
            DayAgenda day = new DayAgenda(this, dateTime);
            return day;
        }

        public Agenda this[int index]
        {
            get
            {
                /* return the specified index here */
                return _agendaList[index];
            }
        }

        protected void NotifyPropertyChanged(object sender,PropertyChangedEventArgs args)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, args);
            }
        }
    }
}
