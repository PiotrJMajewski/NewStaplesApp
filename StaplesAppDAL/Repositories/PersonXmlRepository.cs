using StaplesAppDAL.Interfaces;
using StaplesAppDAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StaplesAppDAL.Repositories
{
    public class PersonXmlRepository: IPersonXmlRepository
    {
        public bool WriteXML(Person person, string folderPath)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer writer =
                    new System.Xml.Serialization.XmlSerializer(typeof(Person));

                var path = folderPath + "\\PersonXmlLog.xml";
                FileStream file = File.Open(path, FileMode.Append, FileAccess.Write);

                writer.Serialize(file, person);
                file.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
