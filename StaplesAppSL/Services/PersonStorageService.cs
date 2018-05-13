﻿using AutoMapper;
using StaplesAppDAL.Interfaces;
using StaplesAppDAL.Repositories;
using StaplesAppSL.Interfaces;
using StaplesAppSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StaplesAppSL.Services
{
    public class PersonStorageService: IPersonStorageService
    {
        IPersonXmlRepository xmlRepository;
        IRepository<StaplesAppDAL.Models.Person> dbRepository;
        IPersonLogRepository logRepository;

        public PersonStorageService(IPersonXmlRepository xmlRepository, IRepository<StaplesAppDAL.Models.Person> dbRepository, 
            IPersonLogRepository logRepository)
        {
            this.xmlRepository = xmlRepository;
            this.dbRepository = dbRepository;
            this.logRepository = logRepository;
        }

        public async Task AddPerson(Person person)
        {
            var dalPerson = Mapper.Map<StaplesAppSL.Models.Person, StaplesAppDAL.Models.Person>(person);

            bool IsPersonExist = await CheckIfPersonExist(person);

            if(!IsPersonExist)
            {
                await dbRepository.AddAsync(dalPerson);
                xmlRepository.WriteXML(dalPerson, HttpContext.Current.Server.MapPath("/App_Data"));
                logRepository.LogPersonEvent(dalPerson);
            }
        } 

        public async Task<List<Person>> GetPeople()
        {
            var dalPeople = await dbRepository.GetWhereAsync();
            var people = Mapper.Map<List<StaplesAppDAL.Models.Person>, List<StaplesAppSL.Models.Person>>(dalPeople);
            return people;
        }

        private async Task<bool> CheckIfPersonExist(Person person)
        {
            var peopleToCheck = await dbRepository.GetWhereAsync(c => String.Equals(c.LastName.Trim().ToUpper(), person.LastName.Trim().ToUpper())
            && String.Equals(c.FirstName.Trim().ToUpper(), person.FirstName.Trim().ToUpper()));

            if (peopleToCheck != null && peopleToCheck.Any())
                return true;
            else
                return false;
        }

    }
}
