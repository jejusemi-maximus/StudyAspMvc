using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyFisrtMVC.Models
{
    public class Guests
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public bool? Attend { get; set; }
    }
}