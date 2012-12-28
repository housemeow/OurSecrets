using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurSecrets
{
    public class Agenda
    {
        private DateTime? _startDateTime;
        private DateTime? _endDateTime;

        public enum ValueEnum
        {
            Important,
            Common,
            Unimportant
        }

        //constructor of agenda
        public Agenda()
        {
            Title = String.Empty;
            Content = String.Empty;
            Place = String.Empty;
            _startDateTime = null;
            _endDateTime = null;
            ReminderDateTime = null;
            IsRemind = false;
            Value = ValueEnum.Common;
        }

        public Agenda(DateTime dateTime)
        {
            Title = String.Empty;
            Content = String.Empty;
            Place = String.Empty;
            _startDateTime = dateTime;
            _endDateTime = dateTime;
            ReminderDateTime = null;
            IsRemind = false;
            Value = ValueEnum.Common;
        }

        public int ID
        {
            get;
            set;
        }

        public String Title
        {
            get;
            set;
        }

        public String Content
        {
            get;
            set;
        }

        public String Place
        {
            get;
            set;
        }

        public DateTime? StartDateTime
        {
            get
            {
                return _startDateTime;
            }
            set
            {
                if (_endDateTime == null)
                {
                    _startDateTime = value;
                    _endDateTime = value;

                }
                else if (value > _endDateTime)//value is bigger
                {
                    _startDateTime = _endDateTime;
                    _endDateTime = value;
                }
                else
                {
                    _startDateTime = value;
                }
            }
        }

        public DateTime? EndDateTime
        {
            get
            {
                return _endDateTime;
            }
            set
            {
                if (_startDateTime == null)
                {
                    _startDateTime = value;
                    _endDateTime = value;

                }
                else if (value < _startDateTime)//value is smaller
                {
                    _endDateTime = _startDateTime;
                    _startDateTime = value;
                }
                else
                {
                    _endDateTime = value;
                }
            }
        }

        public ValueEnum Value
        {
            get;
            set;
        }

        public DateTime? ReminderDateTime
        {
            get;
            set;
        }

        public bool IsRemind
        {
            get;
            set;
        }

        public bool IsChecked
        {
            get;
            set;
        }

        //set reminder
        public void SetReminder(DateTime reminderDateTime)
        {
            IsRemind = true;
            ReminderDateTime = reminderDateTime;
        }

        //clear reminder
        public void ClearReminder()
        {
            IsRemind = false;
            ReminderDateTime = null;
        }
    }
}
