using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Foundation;
using Windows.Storage;

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
            DateTime startDateTime = new DateTime();
            DateTime endDateTime = new DateTime();
            if (dateTime != null)
            {
                int year = dateTime.Value.Year;
                int month = dateTime.Value.Month;
                int day = dateTime.Value.Day;
                startDateTime = new DateTime(year, month, day, 0, 0, 0);
                endDateTime = new DateTime(year, month, day, 23, 59, 59);
            }
            foreach (Agenda agenda in _agendaList)
            {
                if (dateTime == null ^ agenda.StartDateTime == null)
                {
                    continue;
                }
                else if (agenda.StartDateTime <= startDateTime && startDateTime <= agenda.EndDateTime)
                {
                    resultAgenda.Add(agenda);
                }
                else if (agenda.StartDateTime <= endDateTime && endDateTime <= agenda.EndDateTime)
                {
                    resultAgenda.Add(agenda);
                }
                else if (startDateTime <= agenda.StartDateTime && agenda.StartDateTime <= endDateTime)
                {
                    resultAgenda.Add(agenda);
                }
                else if (startDateTime <= agenda.EndDateTime && agenda.EndDateTime <= endDateTime)
                {
                    resultAgenda.Add(agenda);
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

        protected void NotifyPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, args);
            }
        }

        public List<Agenda> GetFreeTimeAgendaList(DateTime dateTime)
        {
            DateTime startDateTime = new DateTime();
            DateTime endDateTime = new DateTime();
            int year = dateTime.Year;
            int month = dateTime.Month;
            int day = dateTime.Day;
            startDateTime = new DateTime(year, month, day, 0, 0, 0);
            endDateTime = new DateTime(year, month, day, 23, 59, 59);


            AgendaSorter dateTimeSorter = new DateTimeSorter();
            List<Agenda> tempList = dateTimeSorter.Sort(GetAgendaList(dateTime));
            List<Agenda> agendaList = new List<Agenda>();
            foreach (Agenda agenda in tempList)
            {
                Agenda newAgenda = new Agenda(agenda.StartDateTime, agenda.EndDateTime);
                agendaList.Add(newAgenda);
            }
            //merge
            for (int i = 0; i < agendaList.Count; i++)
            {
                for (int j = i + 1; j < agendaList.Count; j++)
                {
                    if (agendaList[i].EndDateTime >= agendaList[j].StartDateTime
                        && agendaList[i].EndDateTime <= agendaList[j].EndDateTime)
                    {
                        agendaList[i].EndDateTime = agendaList[j].EndDateTime;
                        agendaList.RemoveAt(j);
                    }
                }
            }
            //change
            List<Agenda> freeTimeAgendaList = new List<Agenda>();
            //first
            if (agendaList.Count > 0)
            {
                if (startDateTime < agendaList[0].StartDateTime)
                {//dateTime的前一天
                    Agenda agenda = new Agenda(startDateTime, agendaList[0].StartDateTime);
                    freeTimeAgendaList.Add(agenda);
                }
                //last
                for (int i = 0; i < agendaList.Count - 1; i++)
                {
                    Agenda agenda = new Agenda(agendaList[i].EndDateTime, agendaList[i + 1].StartDateTime);
                    freeTimeAgendaList.Add(agenda);
                }
                if (agendaList[agendaList.Count - 1].EndDateTime < endDateTime)
                {//dateTime的前一天
                    Agenda agenda = new Agenda(agendaList[agendaList.Count - 1].EndDateTime, endDateTime);
                    freeTimeAgendaList.Add(agenda);
                }
            }
            else
            {
                Agenda agenda = new Agenda(startDateTime, endDateTime);
                freeTimeAgendaList.Add(agenda);
            }
            return freeTimeAgendaList;
        }

        public static string ToXml(List<Agenda> value)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Agenda>));
            StringBuilder stringBuilder = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
                OmitXmlDeclaration = true,
            };
            using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                serializer.Serialize(xmlWriter, value);
            }
            return stringBuilder.ToString();
        }

        protected async void SaveState()
        {
            string localData = ToXml(_agendaList);
            if (!string.IsNullOrEmpty(localData))
            {
                StorageFile localFile =
                    await ApplicationData.Current.LocalFolder.CreateFileAsync(
                        "localData.txt",
                        CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(localFile, localData);
            }
        }

        public static List<Agenda> FromXml(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Agenda>));
            List<Agenda> value;

            using (StringReader stringReader = new StringReader(xml))
            {
                object deserialized = serializer.Deserialize(stringReader);
                value = (List<Agenda>)deserialized;
            }
            return value;
        }

        public Task SaveAgendaList()
        {
            return Task.Run( () => SaveState());
        }

        public async void LoadAgendaList()
        {
            StorageFile localFile;
            try
            {
                localFile = await ApplicationData.Current.LocalFolder.GetFileAsync("localData.txt");
            }
            catch (FileNotFoundException ex)
            {
                localFile = null;
            }
            if (localFile != null)
            {
                string localData = await FileIO.ReadTextAsync(localFile);
                _agendaList = FromXml(localData);
            }
        }
    }
}
