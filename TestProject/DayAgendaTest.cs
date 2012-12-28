using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using OurSecrets;

namespace TestProject
{
    [TestClass]
    public class DayAgendaTest
    {
        private DayAgenda _day;

        [TestInitialize]
        public void Initialize()
        {
            _day = new DayAgenda();
        }

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(0, _day.Count);
        }

        [TestMethod]
        public void TestConstructorByList()
        {
            DateTime dateTime = new DateTime(2012, 1, 2);
            List<Agenda> agendaList = new List<Agenda>();
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
            agendaList.Add(agenda1);
            agendaList.Add(agenda2);
            agendaList.Add(agenda3);
            agendaList.Add(agenda4);
            agendaList.Add(agenda5);
            DayAgenda day = new DayAgenda(agendaList);
            Assert.AreEqual(5, day.Count);
        }

        [TestMethod]
        public void TestAddAgenda()
        {
            DateTime dateTime = new DateTime(2012, 1, 1);
            List<Agenda> agendaList = new List<Agenda>();
            Agenda agenda1 = new Agenda(dateTime);
            agenda1.Title = "agenda1";
            Agenda agenda2 = new Agenda(dateTime);
            agenda2.Title = "agenda2";
            Agenda agenda3 = new Agenda(dateTime);
            agenda3.Title = "agenda3";
            _day.AddAgenda(agenda1);
            Assert.AreEqual("agenda1", _day[0].Title);
            _day.AddAgenda(agenda2);
            Assert.AreEqual("agenda2", _day[1].Title);
            _day.AddAgenda(agenda3);
            Assert.AreEqual("agenda3", _day[2].Title);
        }

        [TestMethod]
        public void TestRemoveAgenda()
        {
            DateTime dateTime = new DateTime(2012, 1, 1);
            List<Agenda> agendaList = new List<Agenda>();
            Agenda agenda1 = new Agenda(dateTime);
            agenda1.Title = "agenda1";
            Agenda agenda2 = new Agenda(dateTime);
            agenda2.Title = "agenda2";
            Agenda agenda3 = new Agenda(dateTime);
            agenda3.Title = "agenda3";
            _day.AddAgenda(agenda1);
            _day.AddAgenda(agenda2);
            _day.AddAgenda(agenda3);
            _day.RemoveAgenda(agenda1);
            Assert.AreEqual(2, _day.Count);
            _day.RemoveAgenda(agenda2);
            Assert.AreEqual(1, _day.Count);
            _day.RemoveAgenda(agenda2);
            Assert.AreEqual(1, _day.Count);
            _day.RemoveAgenda(agenda3);
            Assert.AreEqual(0, _day.Count);
        }
    }
}
