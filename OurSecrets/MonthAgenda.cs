using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OurSecrets
{
    public class MonthAgenda
    {
        private int _year;
        private int _month;
        private Agendas _agendas;
        private List<DayAgenda> _dayList;

        public MonthAgenda(Agendas agendas, int year, int month)
        {
            // TODO: Complete member initialization
            _agendas = agendas;
            agendas.PropertyChanged += NotifyPropertyChanged;
            this._year = year;
            this._month = month;
            UpdateMonth();
        }

        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
            }
        }

        public int Month
        {
            get
            {
                return _month;
            }
            set
            {
                _month = value;
            }
        }

        public int DayCount
        {
            get
            {
                return DateTime.DaysInMonth(_year, _month);
            }
        }

        public int AgendaCount
        {
            get
            {
                int agendaCount = 0;
                foreach (DayAgenda day in _dayList)
                {
                    agendaCount += day.Count;
                }
                return agendaCount;
            }
        }

        protected void NotifyPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            UpdateMonth();
        }

        private void UpdateMonth()
        {
            DateTime startDate = new DateTime(_year, _month, 1);
            int daysInMonth = DateTime.DaysInMonth(_year, _month);
            DateTime endDate = new DateTime(_year, _month, daysInMonth);
            _dayList = _agendas.GetDayList(startDate, endDate);
        }
    }
}
