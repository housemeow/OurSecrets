using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OurSecrets
{
    public class Agenda : INotifyPropertyChanged
    {
        private DateTime? _startDateTime;
        private DateTime? _endDateTime;
        public event PropertyChangedEventHandler PropertyChanged;
        private ValueEnum _value;
        private string _title;
        private string _content;
        private string _place;
        private bool _isRemind;
        private DateTime? _reminderDateTime;
        private bool _isChecked;

        public ValueEnum Value
        {
            get { return _value; }
            set
            {
                Boolean isChanged = value != Value;
                _value = value;
                if (isChanged)
                {
                    NotifyPropertyChanged("Value");
                }
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                Boolean isChanged = value != _title;
                _title = value;
                if (isChanged)
                {
                    NotifyPropertyChanged("Title");
                }
            }
        }

        public string Content
        {
            get { return _content; }
            set
            {
                Boolean isChanged = value != _content;
                _content = value;
                if (isChanged)
                {
                    NotifyPropertyChanged("Content");
                }
            }
        }

        public string Place
        {
            get { return _place; }
            set
            {
                Boolean isChanged = value != _place;
                _place = value;
                if (isChanged)
                {
                    NotifyPropertyChanged("Place");
                }
            }
        }

        public bool IsRemind
        {
            get { return _isRemind; }
            set
            {
                Boolean isChanged = value != _isRemind;
                _isRemind = value;
                if (isChanged)
                {
                    NotifyPropertyChanged("IsRemind");
                }
            }
        }

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                Boolean isChanged = value != _isChecked;
                _isChecked = value;
                if (isChanged)
                {
                    NotifyPropertyChanged("IsChecked");
                }
            }
        }

        public DateTime? ReminderDateTime
        {
            get { return _reminderDateTime; }
            set
            {
                Boolean isChanged = value != _reminderDateTime;
                _reminderDateTime = value;
                if (isChanged)
                {
                    NotifyPropertyChanged("ReminderDateTime");
                }
            }
        }

        public enum ValueEnum
        {
            Important,
            Common,
            Unimportant
        }

        //constructor of agenda
        public Agenda()
        {
            _title = String.Empty;
            _content = String.Empty;
            _place = String.Empty;
            _startDateTime = null;
            _endDateTime = null;
            _reminderDateTime = null;
            _isRemind = false;
            _value = ValueEnum.Common;
        }

        public Agenda(DateTime dateTime)
            : this()
        {
            _startDateTime = dateTime;
            _endDateTime = dateTime;
        }

        public DateTime? StartDateTime
        {
            get
            {
                return _startDateTime;
            }
            set
            {
                Boolean isChanged = value != _startDateTime;
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
                if (isChanged)
                {
                    NotifyPropertyChanged("StartDateTime");
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
                Boolean isChanged = value != _endDateTime;
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
                if (isChanged)
                {
                    NotifyPropertyChanged("EndDateTime");
                }
            }
        }

        //set reminder
        public void SetReminder(DateTime reminderDateTime)
        {
            _isRemind = true;
            _reminderDateTime = reminderDateTime;
        }

        //clear reminder
        public void ClearReminder()
        {
            _isRemind = false;
            _reminderDateTime = null;
        }

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
