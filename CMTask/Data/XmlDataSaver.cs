using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CMTask.Data
{
    internal class XmlDataSaver : IDataSaver
    {
        public void SaveData(ToDoTask dataObject)
        {
            string filePath = AppConfiguration.AppMainArchiveXml;

            var data = new XmlDataAccesser().GetData().ToList();
            data.Add(dataObject);

            XmlSerializer serializer = new XmlSerializer(typeof(List<ToDoTask>));

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(stream, data);
            }
        }

        public void SaveData(IEnumerable<ToDoTask> dataObject)
        {
            string filePath = AppConfiguration.AppMainArchiveXml;

            var data = new XmlDataAccesser().GetData().ToList();
            
            foreach (var item in dataObject)
            {
                data.Add(item);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<ToDoTask>));

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(stream, data);
            }
        }
    }
}
