using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CMTask.Data
{
    internal class XmlDataAccesser : IDataAcess
    {
        public IEnumerable<ToDoTask> GetData()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ToDoTask>));
            using StreamReader fileStream = new StreamReader(new FileStream(AppConfiguration.AppMainArchiveXml, FileMode.OpenOrCreate));

            IEnumerable<ToDoTask> data = new List<ToDoTask>();
            try
            {
                data = (IEnumerable<ToDoTask>)serializer.Deserialize(fileStream);
            }
            catch
            {
                data = null;
            }
            

            return data ?? new List<ToDoTask>();
        }
    }
}
