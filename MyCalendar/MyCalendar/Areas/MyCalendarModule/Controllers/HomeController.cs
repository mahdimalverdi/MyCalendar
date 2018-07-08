using MyCalendarModule.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCalendarModule.Controllers
{
    public class HomeController : Controller
    {
        private string[] Months = new string[] {Resource.Farvardin,Resource.Ordibehesht,Resource.Khordad,
                                                Resource.Tir,Resource.Mordad,Resource.Shahrivar,
                                                Resource.Mehr,Resource.Aban,Resource.Azar,
                                                Resource.Dey,Resource.Bahman,Resource.Esfand};
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // GET: Home
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Month(int? year, int? month)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            if (year == null || month == null)
            {
                year = persianCalendar.GetYear(DateTime.Now);
                month = persianCalendar.GetMonth(DateTime.Now);
            }
            ViewBag.Year = year;
            ViewBag.Month = month;
            var monthList = new List<Tuple<int, string>>();
            for (int i = 0; i < 12; i++)
            {
                monthList.Add(new Tuple<int, string>(i + 1, Months[i]));
            }
            ViewBag.MonthName = Months[(int)month - 1];
            ViewBag.Months = new SelectList(monthList, "item1", "item2");
            using (var ctx = new Context())
            {
                DateTime MinDay = new DateTime((int)year, (int)month, 1, persianCalendar);
                DateTime MaxDay = new DateTime((int)year, (int)month, 1, persianCalendar).AddDays(31);
                return View(ctx.Events.Where(e => e.Time >= MinDay && e.Time <= MaxDay).ToList());
            }
        }

        public ActionResult Week(int? year, int? month, int? day)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            if (year == null || month == null || day == null)
            {
                year = persianCalendar.GetYear(DateTime.Now);
                month = persianCalendar.GetMonth(DateTime.Now);
                day = persianCalendar.GetDayOfMonth(DateTime.Now);
            }
            ViewBag.Year = year;
            ViewBag.Month = month;
            ViewBag.Day = day;
            var monthList = new List<Tuple<int, string>>();
            for (int i = 0; i < 12; i++)
            {
                monthList.Add(new Tuple<int, string>(i + 1, Months[i]));
            }
            ViewBag.MonthName = Months[(int)month - 1];
            ViewBag.Months = new SelectList(monthList, "item1", "item2");
            using (var ctx = new Context())
            {
                DateTime MinDay = new DateTime((int)year, (int)month, (int)day,persianCalendar).AddDays(-((int)(new DateTime((int)year, (int)month, (int)day).DayOfWeek - 1) % 7));
                DateTime MaxDay = new DateTime((int)year, (int)month, (int)day,persianCalendar).AddDays(-((int)(new DateTime((int)year, (int)month, (int)day).DayOfWeek - 1) % 7)).AddDays(7);
                return View(ctx.Events.Where(e=>e.Time>=MinDay&& e.Time <=MaxDay).ToList());
            }
        }

        public ActionResult Day(int? year, int? month, int? day)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            if (year == null || month == null || day == null)
            {
                year = persianCalendar.GetYear(DateTime.Now);
                month = persianCalendar.GetMonth(DateTime.Now);
                day = persianCalendar.GetDayOfMonth(DateTime.Now);
            }
            ViewBag.Year = year;
            ViewBag.Month = month;
            ViewBag.Day = day;
            ViewBag.MonthName = Months[(int)month - 1];
            using (var ctx = new Context())
            {

                return View(ctx.Events.Where(e => e.Time == new DateTime((int)year, (int)month, (int)day, persianCalendar)).ToList());
            }
        }

        [HttpGet]
        public ActionResult AddEvent(int? year, int? month, int? day)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            Event model=new Event();
            if (year != null && month != null && day != null)
            {
                model.Time = new DateTime((int)year, (int)month, (int)day, persianCalendar);
            }
            if (year == null || month == null || day == null)
            {
                year = persianCalendar.GetYear(DateTime.Now);
                month = persianCalendar.GetMonth(DateTime.Now);
                day = persianCalendar.GetDayOfMonth(DateTime.Now);
            }
            ViewBag.Year = year;
            ViewBag.Month = month;
            ViewBag.Day = day;
            ViewBag.MonthName = Months[(int)month - 1];
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEvent(Event model)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            ViewBag.Year = persianCalendar.GetYear(DateTime.Now);
            ViewBag.Month = persianCalendar.GetMonth(DateTime.Now);
            ViewBag.Day = persianCalendar.GetDayOfMonth(DateTime.Now);
            ViewBag.MonthName = Months[(int)persianCalendar.GetMonth(DateTime.Now) - 1];
            using (var ctx = new Context())
            {
                ctx.Events.Add(model);
                ctx.SaveChanges();
            }
            return View();
        }
    }
}