using NUnit.Framework;
using CustomCalendar;
using System.Collections.Generic;
using System.IO;

namespace CustomCalendar_Unit_Testing
{
    public class Tests
    {
        string name1 = "Test";
        string date1 = "12-12-2019";
        string enddate1 = "13-12-2019";
        string title1 = "Testing";
        string description1 = "TestingDescription";
        string recipent1 = "TestingRecipent";
        string login1 = "TestingLogin";
        string password1 = "TestingPassword";
        string location1 = "TestingLocation";
        bool reminder1 = true;
        bool sended1 = false;
        Note note;
        Note noteAlt;
        CustomMail cmail;
        CustomMail altCmail;
        MyEvent mevent;
        MyEvent meventAlt;

        [SetUp]
        public void Setup()
        {
            note = new Note(name1, date1, title1, description1, reminder1);
            noteAlt = new Note(name1);
            cmail = new CustomMail(name1, date1, title1, description1, sended1, login1, password1, recipent1);
            altCmail = new CustomMail(name1);
            mevent = new MyEvent(name1, date1, title1, description1, reminder1, enddate1, location1);
            meventAlt = new MyEvent(name1);

        }

        [Test]
        public void TestConstructor()
        {
            //testing alternative constructor
            Note noteAlt2 = new Note(name1);
            Assert.Pass(note.GetValue("name"), noteAlt2.GetValue("name"));
        }
        [Test]
        public void TestCheckForTable()
        {
            Assert.AreEqual(Note.CheckForTable("Notes"), true);
        }
        [Test]
        public void TestCheckForRow()
        {
            Assert.AreEqual(Note.CheckForRow("Notes", "Test"), true);
        }
        [Test]
        public void TestGetValueName()
        {
            Assert.Pass(note.GetValue("name"), name1);
            Assert.Pass(noteAlt.GetValue("name"), name1);
        }
        [Test]
        public void TestGetValuedate()
        {
            Assert.Pass(note.GetValue("date"), date1);
        }
        [Test]
        public void TestGetValuetitle()
        {
            Assert.Pass(note.GetValue("title"), title1);
        }
        [Test]
        public void TestGetValudescription()
        {
            Assert.Pass(note.GetValue("description"), description1);
        }
        [Test]
        public void TestGetValueReminder()
        {
            Assert.IsTrue(note.GetReminder());
        }
        [Test]
        public void TestInvalidInput()
        {
            Assert.Pass(note.GetValue("asd"), "Invalid Input");
        }
        //alternative constructor
        [Test]
        public void TestGetValueNameAlt()
        {
            Assert.Pass(noteAlt.GetValue("name"), name1);
        }
        [Test]
        public void TestGetValuedateAlt()
        {
            Assert.Pass(noteAlt.GetValue("date"), date1);
        }
        [Test]
        public void TestGetValuetitleAlt()
        {
            Assert.Pass(noteAlt.GetValue("title"), title1);
        }
        [Test]
        public void TestGetValudescriptionAlt()
        {
            Assert.Pass(noteAlt.GetValue("description"), description1);
        }
        [Test]
        public void TestGetValueReminderAlt()
        {
            Assert.IsFalse(noteAlt.GetReminder());
        }
        [Test]
        public void TestInvalidInputAlt()
        {
            Assert.Pass(noteAlt.GetValue("asd"), "Invalid Input");
        }
        [Test]
        public void TestSave()
        {
            note.Save();
            Note savedNote = new Note(name1);
            Assert.AreEqual(note.GetValue("date"), savedNote.GetValue("date"));
        }
        [Test]
        public void TestDelete()
        {
            noteAlt.Save();
            noteAlt.Delete();
            Assert.IsFalse(Note.CheckForRow("Notes", name1));
        }
        [Test]
        public void TestStaticDelete()
        {
            Note note2 = new Note("test2", "01-01-2019", "title2", "description2", false);
            note2.Save();
            Note.StaticDelete("test2");
            Assert.IsFalse(Note.CheckForRow("Notes", "test2"));
        }
        [Test]
        public void TestGetSearch()
        {
            List<string> target = new List<string>();
            Note note3 = new Note("test3", "01-01-2019", "title2", "description2", false);
            target.Add("test3");
            List<string> result = Note.GetSearch("test3");
            Assert.Pass(result.Count.ToString(), "1");
        }

        //testing mail functions

        [Test]
        public void TestMailConstructor()
        {
            //testing alternative constructor
            CustomMail altCmail2 = new CustomMail(name1);
            Assert.Pass(cmail.GetValue("name"), altCmail2.GetValue("name"));
        }
        [Test]
        public void TestCheckForMailTable()
        {
            Assert.AreEqual(Note.CheckForTable("Mails"), true);
        }
        [Test]
        public void TestCheckForMailRow()
        {
            Assert.AreEqual(Note.CheckForRow("Mails", "Test"), true);
        }
        [Test]
        public void TestMailGetValueName()
        {
            Assert.Pass(cmail.GetValue("name"), name1);
            Assert.Pass(altCmail.GetValue("name"), name1);
        }
        [Test]
        public void TestMailGetValuedate()
        {
            Assert.Pass(cmail.GetValue("date"), date1);
        }
        [Test]
        public void TestMailGetValuetitle()
        {
            Assert.Pass(cmail.GetValue("title"), title1);
        }
        [Test]
        public void TestMailGetValudescription()
        {
            Assert.Pass(cmail.GetValue("description"), description1);
        }
        [Test]
        public void TestGetValueSender()
        {
            Assert.IsFalse(cmail.GetSended());
        }
        [Test]
        public void TestMailInvalidInput()
        {
            Assert.Pass(cmail.GetValue("asd"), "Invalid Input");
        }
        [Test]
        public void TestMailGetLogin()
        {
            Assert.Pass(cmail.GetMailValues("login"), login1);
        }
        [Test]
        public void TestMailGetPassword()
        {
            Assert.Pass(cmail.GetMailValues("password"), password1);
        }
        [Test]
        public void TestMailGetRecipent()
        {
            Assert.Pass(cmail.GetMailValues("recipent"), recipent1);
        }
        //alternative constructor
        [Test]
        public void TestMailGetValueNameAlt()
        {
            Assert.Pass(altCmail.GetValue("name"), name1);
        }
        [Test]
        public void TestMailGetValuedateAlt()
        {
            Assert.Pass(altCmail.GetValue("date"), date1);
        }
        [Test]
        public void TestMailGetValuetitleAlt()
        {
            Assert.Pass(altCmail.GetValue("title"), title1);
        }
        [Test]
        public void TestMailGetValudescriptionAlt()
        {
            Assert.Pass(altCmail.GetValue("description"), description1);
        }
        [Test]
        public void TestMailGetValueReminderAlt()
        {
            Assert.IsFalse(altCmail.GetReminder());
        }
        [Test]
        public void TestMailInvalidInputAlt()
        {
            Assert.Pass(altCmail.GetValue("asd"), "Invalid Input");
        }
        [Test]
        public void TestMailLoginAlt()
        {
            Assert.Pass(altCmail.GetMailValues("login"), login1);
        }
        [Test]
        public void TestMailPasswordAlt()
        {
            Assert.Pass(altCmail.GetMailValues("password"), password1);
        }
        [Test]
        public void TestMailRecipentAlt()
        {
            Assert.Pass(altCmail.GetMailValues("recipent"), recipent1);
        }
        [Test]
        public void TestMailSave()
        {
            cmail.Save();
            CustomMail savedMail = new CustomMail(name1);
            Assert.AreEqual(cmail.GetValue("date"), savedMail.GetValue("date"));
        }
        [Test]
        public void TestMailDelete()
        {
            altCmail.Save();
            altCmail.Delete();
            Assert.IsFalse(Note.CheckForRow("Mails", name1));
        }
        [Test]
        public void TestMailStaticDelete()
        {
            CustomMail cmail2 = new CustomMail("test2", "01-01-2019", "title2", "description2", false, "login2", "password2", "recipent2");
            cmail2.Save();
            CustomMail.StaticDelete("test2");
            Assert.IsFalse(CustomMail.CheckForRow("Mails", "test2"));
        }
        [Test]
        public void TestMailGetSearch()
        {
            List<string> target = new List<string>();
            CustomMail cmail3 = new CustomMail("test3", "01-01-2019", "title2", "description2", false, "login3", "password3", "recipent3");
            target.Add("test3");
            List<string> result = CustomMail.GetSearch("test3");
            Assert.Pass(result.Count.ToString(), "1");
        }

        //testing event functions

        [Test]
        public void TestEventConstructor()
        {
            //testing alternative constructor
            MyEvent meventAlt2 = new MyEvent(name1);
            Assert.Pass(mevent.GetValue("name"), meventAlt2.GetValue("name"));
        }
        [Test]
        public void TestMailCheckForTable()
        {
            Assert.AreEqual(MyEvent.CheckForTable("Events"), true);
        }
        [Test]
        public void TestEventCheckForRow()
        {
            Assert.AreEqual(MyEvent.CheckForRow("Events", "Test"), true);
        }
        [Test]
        public void TestEventGetValueName()
        {
            Assert.Pass(mevent.GetValue("name"), name1);
            Assert.Pass(meventAlt.GetValue("name"), name1);
        }
        [Test]
        public void TestEventGetValuedate()
        {
            Assert.Pass(mevent.GetValue("date"), date1);
        }
        [Test]
        public void TestEventGetValuetitle()
        {
            Assert.Pass(mevent.GetValue("title"), title1);
        }
        [Test]
        public void TestEventGetValudescription()
        {
            Assert.Pass(mevent.GetValue("description"), description1);
        }
        [Test]
        public void TestEventGetValueReminder()
        {
            Assert.IsTrue(mevent.GetReminder());
        }
        [Test]
        public void TestEventInvalidInput()
        {
            Assert.Pass(mevent.GetValue("asd"), "Invalid Input");
        }
        [Test]
        public void TestEventGetEndDate()
        {
            Assert.Pass(mevent.GetValue("endDate"), enddate1);
        }
        [Test]
        public void TestEventLocation()
        {
            Assert.Pass(mevent.GetValue("location"), location1);
        }
        //alternative constructor
        [Test]
        public void TestEventGetValueNameAlt()
        {
            Assert.Pass(meventAlt.GetValue("name"), name1);
        }
        [Test]
        public void TestEventGetValuedateAlt()
        {
            Assert.Pass(meventAlt.GetValue("date"), date1);
        }
        [Test]
        public void TestEventGetValuetitleAlt()
        {
            Assert.Pass(meventAlt.GetValue("title"), title1);
        }
        [Test]
        public void TestEventGetValudescriptionAlt()
        {
            Assert.Pass(meventAlt.GetValue("description"), description1);
        }
        [Test]
        public void TestEventGetValueReminderAlt()
        {
            Assert.IsFalse(meventAlt.GetReminder());
        }
        [Test]
        public void TestEventInvalidInputAlt()
        {
            Assert.Pass(meventAlt.GetValue("asd"), "Invalid Input");
        }
        [Test]
        public void TestEventGetValuLocationAlt()
        {
            Assert.Pass(meventAlt.GetEventValues("location"), location1);
        }
        [Test]
        public void TestEventGetValueEndDateAlt()
        {
            Assert.Pass(meventAlt.GetEventValues("endDate"), enddate1);
        }
        [Test]
        public void TestEventSave()
        {
            mevent.Save();
            MyEvent savedEvent = new MyEvent(name1);
            Assert.AreEqual(mevent.GetValue("date"), savedEvent.GetValue("date"));
        }
        [Test]
        public void TestEventDelete()
        {
            meventAlt.Save();
            mevent.Delete();
            Assert.IsFalse(MyEvent.CheckForRow("Events", name1));
        }
        [Test]
        public void TestEventStaticDelete()
        {
            MyEvent mevent2 = new MyEvent("test2", "01-01-2019", "title2", "description2", false, "02-01-2019", "testing location 2");
            mevent2.Save();
            MyEvent.StaticDelete("test2");
            Assert.IsFalse(MyEvent.CheckForRow("Events", "test2"));
        }
        [Test]
        public void TestEventGetSearch()
        {
            List<string> target = new List<string>();
            MyEvent mevent3 = new MyEvent("test3", "01-01-2019", "title2", "description2", false, "02-01-2019", "Testing location 3");
            target.Add("test3");
            List<string> result = MyEvent.GetSearch("test3");
            Assert.Pass(result.Count.ToString(), "1");
        }
        //create json test
        [Test]
        public void TestCreateJson()
        {
            MyEvent.CreateJSon("test", "test", "test");
            FileInfo fileInfo = new FileInfo("credentials.json");
            FileAssert.Exists(fileInfo);
        }
    }
}