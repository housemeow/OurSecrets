using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using OurSecrets;

namespace TestProject
{
    [TestClass]
    public class AgendasTest
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

        }

        [TestMethod]
        public void TestAddAgenda()
        {
            Agenda agenda = new Agenda();
            _agendas.AddAgenda(agenda);
            Assert.AreEqual(1, _agendas.Count);
            _agendas.AddAgenda(agenda);
            Assert.AreEqual(2, _agendas.Count);
        }

        [TestMethod]
        public void TestGetAgendasByDateTime()
        {
            DateTime dateTime1 = new DateTime(2012, 3, 15);
            DateTime dateTime2 = new DateTime(2012, 4, 11);
            Agenda agenda1 = new Agenda(dateTime1);
            agenda1.Title = "dateTime1";
            Agenda agenda2 = new Agenda(dateTime2);
            agenda2.Title = "dateTime2";
            Agenda agenda3 = new Agenda(dateTime1);
            agenda3.Title = "dateTime1";
            Agenda agenda4 = new Agenda(dateTime2);
            agenda4.Title = "dateTime2";
            Agenda agenda5 = new Agenda(dateTime1);
            agenda5.Title = "dateTime1";
            _agendas.AddAgenda(agenda1);
            _agendas.AddAgenda(agenda2);
            _agendas.AddAgenda(agenda3);
            _agendas.AddAgenda(agenda4);
            _agendas.AddAgenda(agenda5);
            List<Agenda> agendaList = _agendas.GetAgendaList(dateTime1);
            Assert.AreEqual(3, agendaList.Count);
            foreach (Agenda agenda in agendaList)
            {
                Assert.AreEqual("dateTime1", agenda.Title);
            }
        }

        [TestMethod]
        public void TestGetAgendaListByDuration()
        {
            DateTime startDateTime = new DateTime(2012, 1, 2);
            DateTime endDateTime = new DateTime(2012, 1, 4); 
            Agenda agenda1 = new Agenda(new DateTime(2012, 1, 1));
            agenda1.Title = "agenda1";
            Agenda agenda2 = new Agenda(startDateTime);
            agenda2.Title = "agenda2";
            Agenda agenda3 = new Agenda(new DateTime(2012, 1, 3));
            agenda3.Title = "agenda3";
            Agenda agenda4 = new Agenda(endDateTime);
            agenda4.Title = "agenda4";
            Agenda agenda5 = new Agenda(new DateTime(2012, 1, 5));
            agenda5.Title = "agenda5";
            _agendas.AddAgenda(agenda1);
            _agendas.AddAgenda(agenda2);
            _agendas.AddAgenda(agenda3);
            _agendas.AddAgenda(agenda4);
            _agendas.AddAgenda(agenda5);
            List<Agenda> agendaList = _agendas.GetAgendaList(startDateTime, endDateTime);
            Assert.AreEqual(3, agendaList.Count);
            Assert.AreEqual("2", agendaList[0].Title);
            Assert.AreEqual("3", agendaList[1].Title);
            Assert.AreEqual("4", agendaList[2].Title);
        }
    }
}
