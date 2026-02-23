using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CMTask.Data
{
    internal class XmlDataEditor : IDataEditor
    {
        public void EditTask(int id, string? title = null, string? description = null)
        {
            var serializer = new XmlSerializer(typeof(List<ToDoTask>));
            
            List<ToDoTask> tasks;
            using (var filestream = new FileStream(AppConfiguration.AppMainArchiveXml, FileMode.Open))
            {
                tasks = serializer.Deserialize(filestream) as List<ToDoTask>;
            }

            using (var filestream = new FileStream(AppConfiguration.AppMainArchiveXml, FileMode.Create))
            { 
                ArgumentNullException.ThrowIfNull(tasks, nameof(tasks));

                tasks[id - 1].Title = title ?? tasks[id - 1].Title;
                tasks[id - 1].Description = description ?? tasks[id - 1].Description;

                serializer.Serialize(filestream, tasks);
            }

        }
        public void EditTask(int id, bool concluded, string? title = null, string? description = null)
        {
            var serializer = new XmlSerializer(typeof(List<ToDoTask>));
            
            List<ToDoTask> tasks;
            using (var filestream = new FileStream(AppConfiguration.AppMainArchiveXml, FileMode.Open))
            {
                tasks = serializer.Deserialize(filestream) as List<ToDoTask>;
            }
            
            using (var filestream = new FileStream(AppConfiguration.AppMainArchiveXml, FileMode.Create))
            {
                ArgumentNullException.ThrowIfNull(tasks, nameof(tasks));

                tasks[id - 1].Title = title ?? tasks[id - 1].Title;
                tasks[id - 1].Description = description ?? tasks[id - 1].Description;
                tasks[id - 1].Concluded = concluded;

                serializer.Serialize(filestream, tasks);
            }

        }
        public void RemoveTask(int id)
        {
            var serializer = new XmlSerializer(typeof(List<ToDoTask>));
            
            List<ToDoTask> tasks;
            
            using (var filestream = new FileStream(AppConfiguration.AppMainArchiveXml, FileMode.Open))
            {
                tasks = serializer.Deserialize(filestream) as List<ToDoTask>;
            }

            using (var filestream = new FileStream(AppConfiguration.AppMainArchiveXml, FileMode.Create))
            {
                for (int i = id; i < tasks.Count; i++)
                    tasks[i].Id--;

                tasks.RemoveAt(id - 1);

                serializer.Serialize(filestream, tasks);
            }

        }
    }
}
