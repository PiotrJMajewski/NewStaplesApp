using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StaplesAppDAL.Repositories
{
    public class PersonXmlRepository<T>
    {

        public void WriteXML(T entity, string folderPath)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(T));

             var path = folderPath + "\\PersonXmlLog.xml";
            FileStream file = File.Open(path, FileMode.Append, FileAccess.Write);

            writer.Serialize(file, entity);
            file.Close();
        }
    }
}
