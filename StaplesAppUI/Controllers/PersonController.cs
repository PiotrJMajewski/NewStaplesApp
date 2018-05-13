using StaplesAppSL.Models;
using StaplesAppSL.Services;
using StaplesAppUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StaplesAppUI.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public PersonController()
        {

        }

        public ActionResult AddPerson()
        {
            var testModel = new PersonViewModel();
            return View(testModel);
        }

        public async Task<ActionResult> SavePerson(Person person)
        {
            var personServicce = new PersonStorageService();
            await personServicce.AddPerson(person);
            return View();
        }
    }
}