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
        private MonthAgenda _month;

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void TestConstructor()
        {
            _month = new MonthAgenda(2012, 3);
            Assert.AreEqual(2012, _month.Year); 
            Assert.AreEqual(3, _month.Month);
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
    }
}
