using StaplesAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaplesAppDAL.Interfaces
{
    public interface IPersonLogRepository
    {
        bool LogPersonEvent(Person person);
    }
}
