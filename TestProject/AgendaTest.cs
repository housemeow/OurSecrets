using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using OurSecrets;

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
    }
}
