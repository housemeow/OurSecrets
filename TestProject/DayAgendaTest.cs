using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using OurSecrets;
using System.ComponentModel;

namespace TestProject
{
    [TestClass]
    public class DayAgendaTest
    {
        private Agendas _agendas;

        [TestInitialize]
        public void Initialize()
        {
            _agendas = new Agendas();
        }

        [TestMethod]
        public void TestConstructor()
        {
            DayAgenda dayAgenda = new DayAgenda(_agendas, new DateTime(2012, 12, 21));
            Assert.AreEqual(0, dayAgenda.Count);
        }

        [TestMethod]
        public void TestConstructorByList()
        {
            DateTime dateTime = new DateTime(2012, 1, 2);
            Agenda agenda1 = new Agenda(dateTime);
            agenda1.Title = "agenda1";
            Agenda agenda2 = new Agenda(dateTime);
            agenda2.Title = "agenda2";
            Agenda agenda3 = new Agenda(dateTime);
            agenda3.Title = "agenda3";
            Agenda agenda4 = new Agenda(dateTime);
            agenda4.Title = "agenda4";
            Agenda agenda5 = new Agenda(dateTime);
            agenda5.Title = "agenda5";
            _agendas.AddAgenda(agenda1);
            _agendas.AddAgenda(agenda2);
            _agendas.AddAgenda(agenda3);
            _agendas.AddAgenda(agenda4);
            _agendas.AddAgenda(agenda5);
            DayAgenda day = new DayAgenda(_agendas, dateTime);
            Assert.AreEqual(5, day.Count);
        }

        [TestMethod]
        public void TestChangeProperty()
        {
            List<string> receivedEvents = new List<string>();
            _agendas.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };

            Agenda agenda = new Agenda();
            _agendas.AddAgenda(agenda);
            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual("AddAgenda", receivedEvents[0]);
            //_title = String.Empty;
            agenda.Title = "newValue";
            Assert.AreEqual(2, receivedEvents.Count);
            Assert.AreEqual("Title", receivedEvents[1]);
            //_content = String.Empty;
            agenda.Content = "newValue";
            Assert.AreEqual(3, receivedEvents.Count);
            Assert.AreEqual("Content", receivedEvents[2]);
            //_place = String.Empty;
            agenda.Place = "newValue";
            Assert.AreEqual(4, receivedEvents.Count);
            Assert.AreEqual("Place", receivedEvents[3]);
            //_startDateTime = null;
            agenda.StartDateTime = new DateTime(2012, 12, 22);
            Assert.AreEqual(5, receivedEvents.Count);
            Assert.AreEqual("StartDateTime", receivedEvents[4]);
            //_endDateTime = null;
            agenda.EndDateTime = new DateTime(2012, 12, 21);
            Assert.AreEqual(6, receivedEvents.Count);
            Assert.AreEqual("EndDateTime", receivedEvents[5]);
            //_reminderDateTime = null;
            agenda.ReminderDateTime = new DateTime(2013, 1, 1);
            Assert.AreEqual(7, receivedEvents.Count);
            Assert.AreEqual("ReminderDateTime", receivedEvents[6]);
            //_isRemind = false;
            agenda.IsRemind = true;
            Assert.AreEqual(8, receivedEvents.Count);
            Assert.AreEqual("IsRemind", receivedEvents[7]);
            //_value = ValueEnum.Common;
            agenda.Value = Agenda.ValueEnum.Important;
            Assert.AreEqual(9, receivedEvents.Count);
            Assert.AreEqual("Value", receivedEvents[8]);
        }

        [TestMethod]
        public void TestPropertyChanged()
        {
            DateTime dateTime = new DateTime(2012, 12, 21);
            DateTime notDateTime = new DateTime(2000, 1, 1);
            DayAgenda dayAgenda = new DayAgenda(_agendas, dateTime);
            Agenda agenda1 = new Agenda(dateTime);
            Agenda agenda2 = new Agenda(notDateTime);
            Assert.AreEqual(0, dayAgenda.Count);
            _agendas.AddAgenda(agenda1);
            Assert.AreEqual(1, dayAgenda.Count);
            _agendas.AddAgenda(agenda2);
            Assert.AreEqual(1, dayAgenda.Count);
        }
    }
}
