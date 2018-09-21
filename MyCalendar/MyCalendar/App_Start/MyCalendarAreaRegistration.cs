using System.Web.Mvc;

namespace MyCalendar
{
    public class MyCalendarAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MyCalendarModule";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "Month",
                "MyCalendar/Month/{year}/{month}",
                new { controller = "Home", action = "Month", year = "", month = "" },
                new string[] { "MyCalendarModule.Controllers" }
            );

            context.MapRoute(
                "Week",
                "MyCalendar/Week/{year}/{month}/{day}",
                new { controller = "Home", action = "Week", year = "", month = "", day = "" },
                new string[] { "MyCalendarModule.Controllers" }
            );

            context.MapRoute(
                "Day",
                "MyCalendar/Day/{year}/{month}/{day}",
                new { controller = "Home", action = "Day", year = "", month = "", day = "" },
                new string[] { "MyCalendarModule.Controllers" }
            );

            context.MapRoute(
                "AddEvent",
                "MyCalendar/AddEvent/",
                new { controller = "Home", action = "AddEvent" },
                new string[] { "MyCalendarModule.Controllers" }
            );

            context.MapRoute(
                "Search",
                "MyCalendar/Search/",
                new { controller = "Home", action = "Search"  },
                new string[] { "MyCalendarModule.Controllers" }
            );
        }
    }
}