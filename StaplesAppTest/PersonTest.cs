using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using StaplesAppDAL.Models;
using StaplesAppDAL.Interfaces;
using StaplesAppSL.Services;
using Moq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using StaplesAppSL.Support;
using StaplesAppDAL.Repositories;

namespace StaplesAppTest
{
    [TestClass]
    public class PersonTest
    {
        private static object isInitialized = false;
        public PersonTest()
        {
            lock(isInitialized)
            {
                if(!(bool)isInitialized)
                {
                    AutoMapperConfiguration.ConfigureAutoMapper();
                    isInitialized = true;
                }                 
            }
                
        }

        private List<StaplesAppDAL.Models.Person> GetTestPeopleList()
        {
            var people = new List<StaplesAppDAL.Models.Person>();
            people.Add(new StaplesAppDAL.Models.Person() { Id = 1, FirstName = "TestFirstName1", LastName = "TestLastName1", });
            people.Add(new StaplesAppDAL.Models.Person() { Id = 2, FirstName = "TestFirstName2", LastName = "TestLastName2", });
            return people;
        }

        private StaplesAppSL.Models.Person GetExistingTestPerson()
        {
            var person = new StaplesAppSL.Models.Person() { Id = 1, FirstName = "TestFirstName1", LastName = "TestLastName1", };
            return person;
        }


        private StaplesAppSL.Models.Person GetNonExistingTestPerson()
        {
            var person = new StaplesAppSL.Models.Person() { Id = 1, FirstName = "TestFirstName3", LastName = "TestLastName3", };
            return person;
        }

        private Mock<IRepository<Person>> GetNewMockedDbRepository()
        {
            var dbRepository = new Mock<IRepository<Person>>();

            dbRepository.Setup(c => c.AddAsync(It.IsAny<StaplesAppDAL.Models.Person>())).Returns(Task.FromResult(true));
            dbRepository.Setup(c => c.GetWhereAsync()).Returns(Task.FromResult(GetTestPeopleList()));

            return dbRepository;
        }
        private Mock<IPersonXmlRepository> GetNewMockedXmlRepository()
        {
            var xmlRepository = new Mock<IPersonXmlRepository>();
            xmlRepository.Setup(c => c.WriteXML(It.IsAny<StaplesAppDAL.Models.Person>(), It.IsAny<String>())).Returns(true);
            return xmlRepository;
        }
        private Mock<IPersonLogRepository> GetNewMockedLogRepository()
        {
            var logRepository = new Mock<IPersonLogRepository>();
            logRepository.Setup(c => c.LogPersonEvent(It.IsAny<StaplesAppDAL.Models.Person>())).Returns(true);
            return logRepository;
        }

        private PersonStorageService GetPersonService(IPersonXmlRepository xmlRepository, IRepository<StaplesAppDAL.Models.Person> dbRepository,
            IPersonLogRepository logRepository)
        {

            return new PersonStorageService(xmlRepository, dbRepository, logRepository);
        }


        [TestMethod]
        public void TryAddExistingPerson()
        {
            var person = GetExistingTestPerson();
            var dbRepository = GetNewMockedDbRepository();
            var xmlRepository = GetNewMockedXmlRepository();
            var logRepository = GetNewMockedLogRepository();
            

            dbRepository.Setup(c => c.GetWhereAsync(It.IsAny<Expression<Func<StaplesAppDAL.Models.Person, bool>>>()))
                .Returns(Task.FromResult(GetTestPeopleList().Where(c => c.LastName == person.LastName).ToList()));

            var personService = GetPersonService(xmlRepository.Object, dbRepository.Object, logRepository.Object);
            var personServiceResult = personService.AddPerson(person,"testPath");

            Assert.IsFalse(personServiceResult.Result);


        }

        [TestMethod]
        public void TryAddNonExistingPerson()
        {
            var person = GetNonExistingTestPerson();
            var dbRepository = GetNewMockedDbRepository();
            var xmlRepository = GetNewMockedXmlRepository();
            var logRepository = GetNewMockedLogRepository();

            dbRepository.Setup(c => c.GetWhereAsync(It.IsAny<Expression<Func<StaplesAppDAL.Models.Person, bool>>>()))
                .Returns(Task.FromResult(GetTestPeopleList().Where(c => c.LastName == person.LastName).ToList()));

            var personService = GetPersonService(xmlRepository.Object, dbRepository.Object, logRepository.Object);
            var personServiceResult = personService.AddPerson(person, "testPath");

            Assert.IsTrue(personServiceResult.Result);

        }

        [TestMethod]
        public void TryGetPeople()
        {
            var dbRepository = GetNewMockedDbRepository();
            var xmlRepository = GetNewMockedXmlRepository();
            var logRepository = GetNewMockedLogRepository();

            var personService = GetPersonService(xmlRepository.Object, dbRepository.Object, logRepository.Object);
            var personServiceResult = personService.GetPeople();

            Assert.IsNotNull(personServiceResult);

        }
    }
}
