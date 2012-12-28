﻿using System;
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
        public void TestGetDayByDateTime()
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
            DayAgenda day = _agendas.GetDay(dateTime1);
            Assert.AreEqual(3, day.Count);
            for (int i = 0; i < day.Count; i++)
            {
                Assert.AreEqual("dateTime1", day[i].Title);
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
            Assert.AreEqual("agenda2", agendaList[0].Title);
            Assert.AreEqual("agenda3", agendaList[1].Title);
            Assert.AreEqual("agenda4", agendaList[2].Title);
        }

        [TestMethod]
        public void TestRemoveAgenda()
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
            _agendas.RemoveAgenda(agenda5);
            Assert.AreEqual(4, _agendas.Count);
            _agendas.RemoveAgenda(agenda4);
            Assert.AreEqual(3, _agendas.Count);
            _agendas.RemoveAgenda(agenda3);
            Assert.AreEqual(2, _agendas.Count);
            _agendas.RemoveAgenda(agenda3);
            Assert.AreEqual(2, _agendas.Count);
            _agendas.RemoveAgenda(agenda2);
            Assert.AreEqual(1, _agendas.Count);
            _agendas.RemoveAgenda(agenda1);
            Assert.AreEqual(0, _agendas.Count);
        }

        [TestMethod]
        public void TestGetAgendasSequenceDays()
        {
            DateTime startDateTime = new DateTime(2012, 1, 1);
            DateTime endDateTime = new DateTime(2012, 1, 5);
            Agenda agenda1 = new Agenda(new DateTime(2012, 1, 1));
            agenda1.Title = "agenda1";
            Agenda agenda2 = new Agenda(new DateTime(2012, 1, 2));
            agenda2.Title = "agenda2";
            Agenda agenda3 = new Agenda(new DateTime(2012, 1, 3));
            agenda3.Title = "agenda3";
            Agenda agenda4 = new Agenda(new DateTime(2012, 1, 4));
            agenda4.Title = "agenda4";
            Agenda agenda5 = new Agenda(new DateTime(2012, 1, 5));
            agenda5.Title = "agenda5";
            _agendas.AddAgenda(agenda1);
            _agendas.AddAgenda(agenda2);
            _agendas.AddAgenda(agenda3);
            _agendas.AddAgenda(agenda4);
            _agendas.AddAgenda(agenda5);
            List<DayAgenda> dayList = _agendas.GetDayList(startDateTime, endDateTime);
            Assert.AreEqual(5, dayList.Count);
            Assert.AreEqual(1, dayList[0].Count);
            Assert.AreEqual(1, dayList[1].Count);
            Assert.AreEqual(1, dayList[2].Count);
            Assert.AreEqual(1, dayList[3].Count);
            Assert.AreEqual(1, dayList[4].Count);
        }

        [TestMethod]
        public void TestModifyRefernece()
        {
            Agenda agenda = new Agenda();
            _agendas.AddAgenda(agenda);
            _agendas[0].Title = "changed";
            Assert.AreEqual("changed", agenda.Title);
        }
    }
}
