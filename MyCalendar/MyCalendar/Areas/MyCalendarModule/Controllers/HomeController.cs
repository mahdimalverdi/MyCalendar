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
            return View();
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

            return View();
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

            return View();
        }
    }
}