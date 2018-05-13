using StaplesAppSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaplesAppUI.Models
{
    public class PersonViewModel
    {
        public Person Person { get; set; }
        public List<Person> People { get; set; } = new List<Person>();
    }
}