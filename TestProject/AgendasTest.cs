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
            DateTime dateTime2 = new DateTime(2012, 4, 11, 3, 4, 5);
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
        public void TestChangePropertyAddAgendaAndRemoveAgenda()
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
            _agendas.AddAgenda(agenda);
            Assert.AreEqual(2, receivedEvents.Count);
            Assert.AreEqual("AddAgenda", receivedEvents[1]);
            _agendas.RemoveAgenda(agenda);
            Assert.AreEqual(3, receivedEvents.Count);
            Assert.AreEqual("RemoveAgenda", receivedEvents[2]);
            _agendas.RemoveAgenda(agenda);
            Assert.AreEqual(4, receivedEvents.Count);
            Assert.AreEqual("RemoveAgenda", receivedEvents[3]);
        }

        [TestMethod]
        public void TestGetFreeTimeAgendaList()
        {
            //20120301
            DateTime dateTime01 = new DateTime(2012, 03, 01);
            DateTime dateTime01_Start = new DateTime(2012, 03, 1, 0, 0, 0);
            DateTime dateTime01_End = new DateTime(2012, 03, 1, 23, 59, 59);
            DateTime dateTime0121 = new DateTime(2012, 3, 1, 21, 1, 0);
            DateTime dateTime0123 = new DateTime(2012, 3, 1, 23, 44, 0);
            //20120302
            DateTime dateTime02 = new DateTime(2012, 03, 02);
            DateTime dateTime02_Start = new DateTime(2012, 03, 2, 0, 0, 0);
            DateTime dateTime02_End = new DateTime(2012, 03, 2, 23, 59, 59);
            DateTime dateTime0201 = new DateTime(2012, 3, 2, 1, 1, 0);
            DateTime dateTime0203 = new DateTime(2012, 3, 2, 3, 1, 0);
            DateTime dateTime0205 = new DateTime(2012, 3, 2, 5, 1, 0);
            
            DateTime dateTime0212 = new DateTime(2012, 3, 2, 12, 1, 0);
            DateTime dateTime0218 = new DateTime(2012, 3, 2, 18, 1, 0);
            DateTime dateTime0222 = new DateTime(2012, 3, 2, 22, 1, 0);
            //20120303
            DateTime dateTime03 = new DateTime(2012, 03, 03);
            DateTime dateTime03_Start = new DateTime(2012, 03, 03, 0, 0, 0);
            DateTime dateTime03_End = new DateTime(2012, 03, 03, 23, 59, 59);
            DateTime dateTime0303 = new DateTime(2012, 3, 3, 3, 1, 0);
            DateTime dateTime0305 = new DateTime(2012, 3, 3, 5, 1, 0);

            Agenda agenda0121_0123 = new Agenda(dateTime0121, dateTime0123);
            Agenda agenda0121_0201 = new Agenda(dateTime0121, dateTime0201);
            Agenda agenda0121_0203 = new Agenda(dateTime0121, dateTime0203);
            Agenda agenda0203_0218 = new Agenda(dateTime0203, dateTime0218);
            Agenda agenda0203_0205 = new Agenda(dateTime0203, dateTime0205);
            Agenda agenda0203_0222 = new Agenda(dateTime0203, dateTime0222);
            Agenda agenda0212_0222 = new Agenda(dateTime0212, dateTime0222);
            Agenda agenda0218_0222 = new Agenda(dateTime0218, dateTime0222);

            Agenda agenda0212_0218 = new Agenda(dateTime0212, dateTime0218);
            Agenda agenda0222_0303 = new Agenda(dateTime0222, dateTime0303);
            /*
             * 0121----0123
             * 0121------------0203
             *                 0203---------------0218
             *                           0212--------------0222
             *                           
             *                           0212-----0218
             *                                             0222---------0303
             */
            _agendas.AddAgenda(agenda0121_0123);
            List<Agenda> agendaList = _agendas.GetFreeTimeAgendaList(dateTime02);
            Assert.AreEqual(1, agendaList.Count);
            Assert.AreEqual(dateTime02_Start, agendaList[0].StartDateTime);
            Assert.AreEqual(dateTime02_End, agendaList[0].EndDateTime);
            //Assert.AreEqual
            _agendas.AddAgenda(agenda0203_0218);
            agendaList = _agendas.GetFreeTimeAgendaList(dateTime02);
            Assert.AreEqual(2, agendaList.Count);
            Assert.AreEqual(dateTime02_Start, agendaList[0].StartDateTime);
            Assert.AreEqual(dateTime0203, agendaList[0].EndDateTime);
            Assert.AreEqual(dateTime0218, agendaList[1].StartDateTime);
            Assert.AreEqual(dateTime02_End, agendaList[1].EndDateTime);
            //
            _agendas.AddAgenda(agenda0203_0222);
            agendaList = _agendas.GetFreeTimeAgendaList(dateTime02);
            Assert.AreEqual(2, agendaList.Count);
            Assert.AreEqual(dateTime02_Start, agendaList[0].StartDateTime);
            Assert.AreEqual(dateTime0203, agendaList[0].EndDateTime);
            Assert.AreEqual(dateTime0222, agendaList[1].StartDateTime);
            Assert.AreEqual(dateTime02_End, agendaList[1].EndDateTime);

            _agendas.RemoveAgenda(agenda0203_0218);
            _agendas.RemoveAgenda(agenda0203_0222);

            _agendas.AddAgenda(agenda0212_0222);
            agendaList = _agendas.GetFreeTimeAgendaList(dateTime02);
            Assert.AreEqual(2, agendaList.Count);
            Assert.AreEqual(dateTime02_Start, agendaList[0].StartDateTime);
            Assert.AreEqual(dateTime0212, agendaList[0].EndDateTime);
            Assert.AreEqual(dateTime0222, agendaList[1].StartDateTime);
            Assert.AreEqual(dateTime02_End, agendaList[1].EndDateTime);
            _agendas.AddAgenda(agenda0203_0205);
            agendaList = _agendas.GetFreeTimeAgendaList(dateTime02);
            Assert.AreEqual(3, agendaList.Count);
            Assert.AreEqual(dateTime02_Start, agendaList[0].StartDateTime);
            Assert.AreEqual(dateTime0203, agendaList[0].EndDateTime);
            Assert.AreEqual(dateTime0205, agendaList[1].StartDateTime);
            Assert.AreEqual(dateTime0212, agendaList[1].EndDateTime);
            Assert.AreEqual(dateTime0222, agendaList[2].StartDateTime);
            Assert.AreEqual(dateTime02_End, agendaList[2].EndDateTime);

            _agendas.AddAgenda(agenda0218_0222);
            agendaList = _agendas.GetFreeTimeAgendaList(dateTime02);
            Assert.AreEqual(3, agendaList.Count);
            Assert.AreEqual(dateTime02_Start, agendaList[0].StartDateTime);
            Assert.AreEqual(dateTime0203, agendaList[0].EndDateTime);
            Assert.AreEqual(dateTime0205, agendaList[1].StartDateTime);
            Assert.AreEqual(dateTime0212, agendaList[1].EndDateTime);
            Assert.AreEqual(dateTime0222, agendaList[2].StartDateTime);
            Assert.AreEqual(dateTime02_End, agendaList[2].EndDateTime);


            _agendas = new Agendas();
            _agendas.AddAgenda(agenda0121_0201);
            _agendas.AddAgenda(agenda0203_0205);
            _agendas.AddAgenda(agenda0212_0218);
            _agendas.AddAgenda(agenda0218_0222);
            agendaList = _agendas.GetFreeTimeAgendaList(dateTime02);
            Assert.AreEqual(3, agendaList.Count);
            Assert.AreEqual(dateTime0201, agendaList[0].StartDateTime);
            Assert.AreEqual(dateTime0203, agendaList[0].EndDateTime);
            Assert.AreEqual(dateTime0205, agendaList[1].StartDateTime);
            Assert.AreEqual(dateTime0212, agendaList[1].EndDateTime);
            Assert.AreEqual(dateTime0222, agendaList[2].StartDateTime);
            Assert.AreEqual(dateTime02_End, agendaList[2].EndDateTime);

            _agendas = new Agendas();
            _agendas.AddAgenda(agenda0121_0201);
            _agendas.AddAgenda(agenda0203_0205);
            _agendas.AddAgenda(agenda0212_0218);
            _agendas.AddAgenda(agenda0222_0303);
            agendaList = _agendas.GetFreeTimeAgendaList(dateTime02);
            Assert.AreEqual(3, agendaList.Count);
            Assert.AreEqual(dateTime0201, agendaList[0].StartDateTime);
            Assert.AreEqual(dateTime0203, agendaList[0].EndDateTime);
            Assert.AreEqual(dateTime0205, agendaList[1].StartDateTime);
            Assert.AreEqual(dateTime0212, agendaList[1].EndDateTime);
            Assert.AreEqual(dateTime0218, agendaList[2].StartDateTime);
            Assert.AreEqual(dateTime0222, agendaList[2].EndDateTime);



            //_agendas.AddAgenda(agenda030121_030203);
            //_agendas.AddAgenda(agenda030212_030218);
            //_agendas.AddAgenda(agenda030222_030303);
        }
    }
}
