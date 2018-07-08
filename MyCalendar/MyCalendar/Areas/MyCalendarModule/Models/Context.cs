using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyCalendarModule.Models
{
    public class Context:DbContext
    {
        public Context()
            : base("DefaultConnection")
        {
        }
        public virtual DbSet<Event> Events { set; get; }
        public static Context Create()
        {
            return new Context();
        }
    }
}