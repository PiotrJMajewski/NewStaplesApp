using NLog;
using StaplesAppDAL.Interfaces;
using StaplesAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaplesAppDAL.Repositories
{
    public class PersonLogRepository: IPersonLogRepository
    {
        public bool LogPersonEvent(Person person)
        {
            try
            {
                Logger logger = LogManager.GetLogger("Person");
                LogEventInfo logEvent = new LogEventInfo(LogLevel.Info, "Person", "Adding new person details");
                logEvent.Properties["FirstName"] = person.FirstName;
                logEvent.Properties["LastName"] = person.LastName;
                logger.Log(logEvent);
                return true;
            }
            catch
            {
                return false;
            }

        }

        
        


        

    }
}
