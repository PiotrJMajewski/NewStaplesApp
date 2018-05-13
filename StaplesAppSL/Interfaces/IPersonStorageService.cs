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
        Task AddPerson(Person person);
        Task<List<Person>> GetPeople();
    }
}
