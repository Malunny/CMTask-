using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using TaskWorking.Model;

namespace TaskWorking.Data
{
    internal class CsvDataSaver
    {
        public void SaveData(string filePath, ToDoTask dataObject)
        {
            string[] properties = Array.ConvertAll(typeof(ToDoTask).GetProperties(), property => property.Name);

            if (File.Exists(filePath) == false)
                File.Create(filePath).Close();
            
            string[] archiveLines = File.ReadAllLines(filePath, Encoding.UTF8);

            using StreamWriter writter = new StreamWriter(filePath, true, Encoding.UTF8);

            if (archiveLines.Length == 0)
                writter.WriteLine(string.Join(",", properties));
            
            if (dataObject.Id == 0)
                dataObject.Id = archiveLines.Length;

            string[] taskItens = Array.ConvertAll(typeof(ToDoTask).GetProperties(),
                property => property.GetValue(dataObject)?.ToString() ?? string.Empty);

            writter.WriteLine(string.Join(",", taskItens));
        }

        public void SaveData(string filePath, IEnumerable<ToDoTask> dataObject)
        {
            string[] properties = Array.ConvertAll(typeof(ToDoTask).GetProperties(), property => property.Name);

            if (File.Exists(filePath) == false)
                File.Create(filePath).Close();
            string[] archiveLines = File.ReadAllLines(filePath, Encoding.UTF8);

            using StreamWriter writter = new StreamWriter(filePath, true);

            if (archiveLines.Length == 0)
                writter.WriteLine(string.Join(",", properties));

            int idNumerator = (archiveLines.Length) == 0 ? 1 : archiveLines.Length;

            foreach (ToDoTask item in dataObject)
            {
                item.Id = idNumerator++;
                writter.WriteLine(string.Join(",",
                    Array.ConvertAll(typeof(ToDoTask).GetProperties(),
                    property => property.GetValue(item)?.ToString() ?? string.Empty)));
            }
        }
    }
}
