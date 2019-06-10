using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HOCBusiness.Domain;
using HOCBusiness.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace HOCBusiness.Controllers
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }

    public class HomeController : Controller
    {
        private readonly CalendarService _calendarService;

        private readonly string _dayOffset;

        private readonly string _house;

        private readonly string _eventType;
        public HomeController(CalendarService calendarService, IConfiguration config)
        {
            _calendarService = calendarService;
            _dayOffset = config.GetSection("CalendarService")["DayOffset"];
            _house = config.GetSection("CalendarService")["HouseType"];
            _eventType = config.GetSection("CalendarService")["EventType"];
        }

        public IActionResult Index()
        {
            DateTime? startDate = null;
            if (Request.Query["startDate"].FirstOrDefault() != null)
            {
                startDate = DateTime.Parse(Request.Query["startDate"].FirstOrDefault()).StartOfWeek(DayOfWeek.Monday);
            }
            if (startDate == null)
                startDate = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            ViewBag.StartDate = startDate;
            var endDate = startDate.GetValueOrDefault().AddDays(int.Parse(_dayOffset));
            ViewBag.EndDate = endDate;

            string house = _house;
            if (Request.Query["house"].FirstOrDefault() != null)
                house = Request.Query["house"];
            ViewBag.House = house;
            string eventType = _eventType;
            if (Request.Query["eventType"].FirstOrDefault() != null)
                eventType = Request.Query["eventType"];
            ViewBag.EventType = eventType;

            string orderByStart = "Descending";
            if (Request.Query["orderByStart"].FirstOrDefault() != null)
                orderByStart = Request.Query["orderByStart"];
            ViewBag.OrderByStart = orderByStart;

            return View(_calendarService.GetEvents(startDate.GetValueOrDefault(), endDate, eventType == EventType.All ? null : eventType, house == HouseType.Both ? null : house, orderByStart));
        }
    }
}
