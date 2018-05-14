using StaplesAppSL.Interfaces;
using StaplesAppSL.Models;
using StaplesAppSL.Services;
using StaplesAppUI.Interfaces;
using StaplesAppUI.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StaplesAppUI.Controllers
{
    public class PersonController : Controller, IPersonController
    {
        IPersonStorageService personService;

        public PersonController(IPersonStorageService personService)
        {
            this.personService = personService;
        }

        public async Task<ActionResult> AddPerson()
        {
            var personViewModel = new PersonViewModel();
            personViewModel.People = await personService.GetPeople();
            return View(personViewModel) ;
        }

        [HttpPost]
        public async Task<JsonResult> SavePerson(Person person)
        {
            var isPersonSaved = await personService.AddPerson(person, HttpContext.Server.MapPath("/App_Data"));

            if (isPersonSaved)
                return Json("success");
            else
                return Json("failed");
        }
    }
}

