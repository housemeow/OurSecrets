using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using OurSecrets;

namespace TestProject
{
    [TestClass]
    public class MonthAgendaTest
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
            MonthAgenda month = new MonthAgenda(_agendas, 2012, 3);
            Assert.AreEqual(2012, month.Year);
            Assert.AreEqual(3, month.Month);
        }

        [TestMethod]
        public void TestConstructorByList()
        {
            DateTime dateTime = new DateTime(2012, 1, 2);
            //List<Agenda> agendaList = new List<Agenda>();
            Agendas agendas = new Agendas();
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
            agendas.AddAgenda(agenda1);
            agendas.AddAgenda(agenda2);
            agendas.AddAgenda(agenda3);
            agendas.AddAgenda(agenda4);
            agendas.AddAgenda(agenda5);
            DayAgenda day = new DayAgenda(agendas, dateTime);
            Assert.AreEqual(5, day.Count);
        }

        [TestMethod]
        public void TestPropertyChanged()
        {
            DateTime sameMonthDateTime1 = new DateTime(2012, 3, 30);
            DateTime sameMonthDateTime2 = new DateTime(2012, 3, 1);
            DateTime notDateTime = new DateTime(2000, 1, 1);
            MonthAgenda month = new MonthAgenda(_agendas, 2012, 3);
            Agenda agenda1 = new Agenda(sameMonthDateTime1);
            Agenda agenda2 = new Agenda(sameMonthDateTime2);
            Agenda notAgenda = new Agenda(notDateTime);

            Assert.AreEqual(0, month.AgendaCount);
            _agendas.AddAgenda(agenda1);
            Assert.AreEqual(1, month.AgendaCount);
            _agendas.AddAgenda(agenda2);
            Assert.AreEqual(2, month.AgendaCount);
            _agendas.AddAgenda(notAgenda);
            Assert.AreEqual(2, month.AgendaCount);
        }

        [TestMethod]
        public void TestSaveAgendaList()
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


            _agendas.SaveAgendaList();
        }
    }
}
