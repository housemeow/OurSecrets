using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurSecrets
{
    public class MonthAgenda
    {
        private int _year;
        private int _month;

        public MonthAgenda(int year, int month)
        {
            // TODO: Complete member initialization
            this._year = year;
            this._month = month;
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


        public object DayCount
        {
            get
            {
                return DateTime.DaysInMonth(_year, _month);
            }
        }
    }
}
