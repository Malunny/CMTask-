using CMTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using TaskWorking.Configuration;
using TaskWorking.Model;
using TaskWorking.Service;

namespace TaskWorking.Data
{
    internal class CsvDataAccesser : IDataAcess
    {
        public static string MainDirectoryPath = AppConfiguration.AppDirectory;

        public IEnumerable<ToDoTask> GetData()
        {
            string filePath = AppConfiguration.AppMainArchiveCsv;

            List<ToDoTask> dataList = new List<ToDoTask>();

            if (File.Exists(filePath))
            {
                using StreamReader reader = new StreamReader(filePath, Encoding.UTF8);
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    ReadOnlySpan<char> values = reader.ReadLine();
                    ReadOnlySpan<char> imutableValues = values;
                    
                    int separator = values.IndexOf(',');
                    int idSeparator = separator;
                    
                    values = values.Slice(separator + 1);
                    
                    separator = values.IndexOf(',');
                    int titleSeparator = separator;
                    
                    values = values.Slice(separator + 1); // ?
                    separator = values.IndexOf(',');
                    int descriptionSeparator = separator;
                    
                    values = values.Slice(separator + 1);
                    separator = values.IndexOf(',');
                    int concludedSeparator = separator;
                    
                    ToDoTask item = new ToDoTask()
                    {
                        Id = TryCatchIntConverter.ConvertStringToInt(imutableValues.Slice(0,idSeparator).ToString()),
                        Title = imutableValues.Slice(idSeparator + 1, titleSeparator).ToString(),
                        Description = imutableValues.Slice(idSeparator + titleSeparator + 2, descriptionSeparator).ToString(),
                        Concluded = imutableValues.Slice(idSeparator + titleSeparator + descriptionSeparator + 1).ToString()
                                                        == "true" ? true : false 
                    };
                    dataList.Add(item);
                }
                return dataList;
            }
            else
            {
                throw new FileNotFoundException($"The file at path {filePath} was not found.");
            }
        }
        
        
        public string[] GetDirectories()
        {
            string[] directories = Directory.GetDirectories("C:\\CSVDataArchives");
            if (directories.Length == 0)
                return new string[] {"Nenhum diretório para arquivos CSV criado."};
            return directories;
        }
    }
}
