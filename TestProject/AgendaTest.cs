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
    public class AgendaTest
    {
        private Agenda _agenda;

        [TestInitialize]
        public void Initialize()
        {
            _agenda = new Agenda();
        }

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(String.Empty, _agenda.Title);
            Assert.AreEqual(String.Empty, _agenda.Content);
            Assert.AreEqual(String.Empty, _agenda.Place);
            Assert.AreEqual(null, _agenda.StartDateTime);
            Assert.AreEqual(null, _agenda.EndDateTime);
            Assert.AreEqual(Agenda.ValueEnum.Common, _agenda.Value);
            Assert.IsFalse(_agenda.IsRemind);
            Assert.AreEqual(null, _agenda.ReminderDateTime);
            Assert.IsFalse(_agenda.IsChecked);
        }

        [TestMethod]
        public void TestConstructorByDateTime()
        {
            DateTime dateTime = new DateTime(2012, 3, 15);
            Agenda agenda = new Agenda(dateTime);
            Assert.AreEqual(String.Empty, agenda.Title);
            Assert.AreEqual(String.Empty, agenda.Content);
            Assert.AreEqual(String.Empty, agenda.Place);
            Assert.AreEqual(dateTime, agenda.StartDateTime);
            Assert.AreEqual(dateTime, agenda.EndDateTime);
            Assert.AreEqual(Agenda.ValueEnum.Common, agenda.Value);
            Assert.IsFalse(agenda.IsRemind);
            Assert.AreEqual(null, agenda.ReminderDateTime);
            Assert.IsFalse(agenda.IsChecked);
        }

        [TestMethod]
        public void TestStartDateTime()
        {
            DateTime startDateTime = new DateTime(2012, 10, 3);
            DateTime endDateTime = new DateTime(2012, 10, 5);
            _agenda.EndDateTime = startDateTime;
            Assert.AreEqual(startDateTime, _agenda.StartDateTime);
            _agenda.StartDateTime = endDateTime;
            Assert.AreEqual(startDateTime, _agenda.StartDateTime);
        }

        [TestMethod]
        public void TestEndDateTime()
        {
            DateTime startDateTime = new DateTime(2012, 10, 3);
            DateTime endDateTime = new DateTime(2012, 10, 5);
            _agenda.StartDateTime = endDateTime;
            Assert.AreEqual(endDateTime, _agenda.EndDateTime);
            _agenda.EndDateTime = startDateTime;
            Assert.AreEqual(endDateTime, _agenda.EndDateTime);
        }

        [TestMethod]
        public void TestSetReminder()
        {
            DateTime remindDateTime = new DateTime(2012, 3, 15);
            _agenda.SetReminder(remindDateTime);
            Assert.IsTrue(_agenda.IsRemind);
            Assert.AreEqual(remindDateTime, _agenda.ReminderDateTime);
        }

        [TestMethod]
        public void TestClearReminder()
        {
            DateTime remindDateTime = new DateTime(2012, 3, 15);
            _agenda.SetReminder(remindDateTime);
            _agenda.ClearReminder();
            Assert.IsFalse(_agenda.IsRemind);
            Assert.AreEqual(null, _agenda.ReminderDateTime);
        }

        [TestMethod]
        public void TestChangeProperty()
        {
            List<string> receivedEvents = new List<string>();
            _agenda.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };

            //_title = String.Empty;
            _agenda.Title = "newValue";
            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual("Title", receivedEvents[0]);
            //_content = String.Empty;
            _agenda.Content = "newValue";
            Assert.AreEqual(2, receivedEvents.Count);
            Assert.AreEqual("Content", receivedEvents[1]);
            //_place = String.Empty;
            _agenda.Place = "newValue";
            Assert.AreEqual(3, receivedEvents.Count);
            Assert.AreEqual("Place", receivedEvents[2]);
            //_startDateTime = null;
            _agenda.StartDateTime = new DateTime(2012, 12, 22);
            Assert.AreEqual(4, receivedEvents.Count);
            Assert.AreEqual("StartDateTime", receivedEvents[3]);
            //_endDateTime = null;
            _agenda.EndDateTime = new DateTime(2012, 12, 21);
            Assert.AreEqual(5, receivedEvents.Count);
            Assert.AreEqual("EndDateTime", receivedEvents[4]);
            //_reminderDateTime = null;
            _agenda.ReminderDateTime = new DateTime(2013, 1, 1);
            Assert.AreEqual(6, receivedEvents.Count);
            Assert.AreEqual("ReminderDateTime", receivedEvents[5]);
            //_isRemind = false;
            _agenda.IsRemind = true;
            Assert.AreEqual(7, receivedEvents.Count);
            Assert.AreEqual("IsRemind", receivedEvents[6]);
            //_value = ValueEnum.Common;
            _agenda.Value = Agenda.ValueEnum.Important;
            Assert.AreEqual(8, receivedEvents.Count);
            Assert.AreEqual("Value", receivedEvents[7]);
        }
    }
}
