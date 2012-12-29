using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using OurSecrets;

namespace TestProject
{
    [TestClass]
    public class AgendaSorterTest
    {
        private AgendaSorter _agendaSorter;
        private List<Agenda> _agendaList;

        [TestInitialize]
        public void Initialize()
        {
            _agendaList = new List<Agenda>();
            Agenda agenda1 = new Agenda(new DateTime(2012, 1, 1));
            agenda1.Value = Agenda.ValueEnum.Unimportant;
            agenda1.Title = "agenda1";
            Agenda agenda2 = new Agenda(new DateTime(2012, 1, 3));
            agenda2.Value = Agenda.ValueEnum.Important;
            agenda2.Title = "agenda2";
            Agenda agenda3 = new Agenda(new DateTime(2012, 1, 5));
            agenda3.Value = Agenda.ValueEnum.Important;
            agenda3.Title = "agenda3";
            Agenda agenda4 = new Agenda(new DateTime(2012, 1, 4));
            agenda4.Value = Agenda.ValueEnum.Common;
            agenda4.Title = "agenda4";
            Agenda agenda5 = new Agenda(new DateTime(2012, 1, 2));
            agenda5.Value = Agenda.ValueEnum.Important;
            agenda5.Title = "agenda5";
            _agendaList.Add(agenda1);
            _agendaList.Add(agenda2);
            _agendaList.Add(agenda3);
            _agendaList.Add(agenda4);
            _agendaList.Add(agenda5);
        }

        [TestMethod]
        public void TestDateTimeSorter()
        {
            _agendaSorter = new DateTimeSorter();
            List<Agenda> sortedAgendaList = _agendaSorter.Sort(_agendaList);
            Assert.AreEqual(5, sortedAgendaList.Count);
            Assert.AreEqual("agenda1", sortedAgendaList[0].Title);
            Assert.AreEqual("agenda5", sortedAgendaList[1].Title);
            Assert.AreEqual("agenda2", sortedAgendaList[2].Title);
            Assert.AreEqual("agenda4", sortedAgendaList[3].Title);
            Assert.AreEqual("agenda3", sortedAgendaList[4].Title);
        }

        [TestMethod]
        public void TestValueSorter()
        {
        }


    }
}
