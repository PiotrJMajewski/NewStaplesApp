using StaplesAppSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaplesAppSL.Interfaces
{
    public interface IPersonStorageService
    {
        Task<bool> AddPerson(Person person,  string appDataPath);
        Task<List<Person>> GetPeople();
    }
}
