using StaplesAppSL.Models;
using StaplesAppSL.Services;
using StaplesAppUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<ActionResult> AddPerson()
        {
            var personService = new PersonStorageService();
            var testModel = new PersonViewModel();
            testModel.People = await personService.GetPeople();
            return View(testModel);
        }

        [HttpPost]
        public async Task<JsonResult> SavePerson(Person person)
        {
            var personService = new PersonStorageService();
            await personService.AddPerson(person);
            return Json("success");
        }
    }
}