using AutoMapper;
using StaplesAppDAL.Repositories;
using StaplesAppSL.Models;
using StaplesAppSL.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StaplesAppSL.Services
{
    public class PersonStorageService
    {  
        public PersonStorageService()
        {
        }

        public async Task AddPerson(Person person)
        {
            var xmlRepository = new PersonXmlRepository<StaplesAppDAL.Models.Person>();
            var dbRepository = new PersonDbRepository();
            var logRepository = new PersonLogRepository();

            var dalPerson = Mapper.Map<StaplesAppSL.Models.Person, StaplesAppDAL.Models.Person>(person);

            xmlRepository.WriteXML(dalPerson, HttpContext.Current.Server.MapPath("/App_Data"));

            
            await dbRepository.AddAsync(dalPerson);
            logRepository.LogPersonEvent(dalPerson);
        }

        public async Task<List<Person>> GetPeople()
        {
            var dbRepository = new PersonDbRepository();
            var dalPeople = await dbRepository.GetWhereAsync();
            var people = Mapper.Map<List<StaplesAppDAL.Models.Person>, List<StaplesAppSL.Models.Person>>(dalPeople);
            return people;

        }

    }
}
