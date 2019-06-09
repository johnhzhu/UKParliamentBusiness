using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HOCBusiness.Services;
using HOCBusiness.Domain;
using System.Collections.Generic;
using System.Linq;

namespace HOCBusiness.UnitTest
{
    [TestClass]
    public class CalendarServiceTest
    {
        [TestMethod]
        public void CalendarDataCheck()
        {
            var startDate = new DateTime(2019, 6, 3);
            var endDate = new DateTime(2019, 6, 7);
            string eventType = EventType.MainChamber;
            string house = HouseType.Commons;
            var data = GetCalendarData(startDate, endDate, eventType, house, "Ascending");
            Assert.IsTrue(data.Where(e => e.StartDate >= startDate && e.EndDate <= endDate).Count() == data.Count());
            Assert.IsTrue(data.Count() > 0);
        }

        [TestMethod]
        public void OutputResponse()
        {
            var startDate = new DateTime(2019, 6, 3);
            var endDate = new DateTime(2019, 6, 7);
            string eventType = EventType.MainChamber;
            string house = HouseType.Commons;
            var data = GetCalendarData(startDate, endDate, eventType, house, null);

            foreach (Event e in data)
            {
                Console.WriteLine();
                Console.WriteLine($"Category: {e.Category}");
                if (e.Committee != null)
                {
                    Console.WriteLine($"Committee Description: {e.Committee.Description}");
                    Console.WriteLine($"Committee Id: {e.Committee.Id}");
                }
                Console.WriteLine($"Description: {e.Description}");
                Console.WriteLine($"EndDate: {e.EndDate?.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"EndTime: {e.EndTime}");
                Console.WriteLine($"HasSpeakers: {e.HasSpeakers}");
                Console.WriteLine($"House: {e.House}");
                Console.WriteLine($"Id: {e.Id}");
                Console.WriteLine($"Location: {e.Location}");
                Console.WriteLine($"LocationMetadata: {e.LocationMetadata}");
                foreach (EventMember m in e.Members)
                {
                    Console.WriteLine($"Member Id: {m.Id}");
                    Console.WriteLine($"Member Name: {m.Name}");
                }
                foreach (object o in e.Metadata)
                {
                    Console.WriteLine($"Metadata: {o.ToString()}");
                }
                if (e.Notes != null)
                    Console.WriteLine($"Notes: {e.Notes.ToString()}");
                Console.WriteLine($"SortOrder: {e.SortOrder}");
                Console.WriteLine($"StartDate: {e.StartDate?.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"StartTime: {e.StartTime}");
                Console.WriteLine($"SummarisedDetails: {e.SummarisedDetails}");
                foreach (object o in e.Tags)
                {
                    Console.WriteLine($"Tag: {o.ToString()}");
                }
            }
        }

        private IEnumerable<Event> GetCalendarData(DateTime startDate, DateTime endDate, string eventType, string house, string orderBy)
        {
            return new CalendarService().GetEvents(startDate, endDate, eventType, house, orderBy);
        }
    }
}
