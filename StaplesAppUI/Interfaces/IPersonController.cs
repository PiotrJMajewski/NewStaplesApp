using StaplesAppSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StaplesAppUI.Interfaces
{
    public interface IPersonController
    {
        Task<ActionResult> AddPerson();
        Task<JsonResult> SavePerson(Person person);
    }
}
