using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Workshops.Models
{
    public class WorkshopWithDetails
    {
        public int? Id { get; set; }


        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public string Place { get; set; }

        public DateTime Time { get; set; }
    }
}