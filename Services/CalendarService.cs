using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using HOCBusiness.Domain;
using Newtonsoft.Json;
using System.Linq;

namespace HOCBusiness.Services
{
    public class CalendarService : BaseService
    {
        private readonly string _baseUrl = "http://service.calendar.parliament.uk/calendar/events/list.json?";
        public CalendarService()
        {
            this.BaseUrl = _baseUrl;
        }
        public IEnumerable<Event> GetEvents(DateTime startDate, DateTime endDate, string eventType, string house, string orderByStart)
        {
            string queryString = $"startdate={startDate.ToString("yyyy-MM-dd")}&enddate={endDate.ToString("yyyy-MM-dd")}";
            var events = base.DeserialiseJson<IEnumerable<Event>>($"{this.BaseUrl}{queryString}");
            if ( !string.IsNullOrWhiteSpace(eventType) )
                events = events.Where(e => e.Type == eventType);

            if ( !string.IsNullOrWhiteSpace(house) )
                events = events.Where(e => e.House == house);

            if (orderByStart == "Ascending")
                events = events.OrderBy(e => e.StartDate);
            else if (orderByStart == "Descending")
                events = events.OrderByDescending(e => e.StartDate);

            return events;
        }
    }
}
