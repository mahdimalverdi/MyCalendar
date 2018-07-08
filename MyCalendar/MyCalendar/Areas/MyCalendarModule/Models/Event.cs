using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCalendarModule.Models
{
    public class Event
    {
        [Key]
        public int Id { set; get; }
        [Display(Name =nameof(Resource.Title),ResourceType =typeof(Resource))]
        [Required(ErrorMessageResourceName = nameof(Resource.ErrorMessageRequired), ErrorMessageResourceType = typeof(Resource))]
        public string Title { set; get; }
        [Display(Name = nameof(Resource.Time), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = nameof(Resource.ErrorMessageRequired), ErrorMessageResourceType = typeof(Resource))]
        public DateTime Time { set; get; }
        [Display(Name = nameof(Resource.Color), ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = nameof(Resource.ErrorMessageRequired), ErrorMessageResourceType = typeof(Resource))]
        public string Color { set; get; }

    }
}