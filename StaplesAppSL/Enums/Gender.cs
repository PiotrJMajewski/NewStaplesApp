using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StaplesAppSL.Enums
{
    public enum Gender
    {
        [Display(Name = "-")]
        Undefined = 0,
        [Display(Name = "Male")]
        Male = 1,
        [Display(Name = "Female")]
        Female = 2,
    }
}
