using System;
using System.Collections.Generic;
using System.Text;

namespace TaskWorking.Data
{
    internal class CsvDataEditor : IDataEditor
    {
        public void EditTask(int itemId, string? title = null, string? description = null)
        {
            string pathArchive = AppConfiguration.AppMainArchiveCsv;

            string[] lines = File.ReadAllLines(pathArchive, Encoding.UTF8);
            ReadOnlySpan<char> propertiesLine = lines[itemId];
            string[] properties = new string[4];

            properties[0] = propertiesLine.Slice(0,propertiesLine.IndexOf(",")).ToString();
            propertiesLine = propertiesLine.Slice(propertiesLine.IndexOf(",") + 1);
            
            properties[1] = propertiesLine.Slice(0,propertiesLine.IndexOf(",")).ToString();
            propertiesLine = propertiesLine.Slice(propertiesLine.IndexOf(",") + 1);

            properties[2] = propertiesLine.Slice(0,propertiesLine.LastIndexOf(",")).ToString();
            propertiesLine = propertiesLine.Slice(propertiesLine.LastIndexOf(",") + 1);

            properties[3] = propertiesLine.ToString();

            if (title != null)
                properties[1] = title;
            if (description != null) 
                properties[2] = description;

            lines[itemId] = string.Join(",", properties);
            File.WriteAllLines(pathArchive, lines);
        }

        public void RemoveTask(int itemId)
        {
            string pathArchive = AppConfiguration.AppMainArchiveCsv;
            List<string> lines = new List<string>(File.ReadAllLines(pathArchive, Encoding.UTF8));

            for (int i = lines.Count - 1; i > itemId; i--)
            {
                ReadOnlySpan<char> propertiesLine = lines[i];
                string[] properties = new string[4];

                properties[0] = propertiesLine.Slice(0, propertiesLine.IndexOf(',')).ToString();
                propertiesLine = propertiesLine.Slice(propertiesLine.IndexOf(',') + 1);

                properties[1] = propertiesLine.Slice(0, propertiesLine.IndexOf(',')).ToString();
                propertiesLine = propertiesLine.Slice(propertiesLine.IndexOf(',') + 1);

                properties[2] = propertiesLine.Slice(0, propertiesLine.LastIndexOf(',')).ToString();
                propertiesLine = propertiesLine.Slice(propertiesLine.LastIndexOf(',') + 1);

                properties[3] = propertiesLine.ToString();

                properties[0] = (int.Parse(properties[0]) - 1).ToString();

                lines[i] = string.Join(",", properties);
            }
            lines.RemoveAt(itemId);
            File.WriteAllLines(pathArchive, lines);
        }
    }
}
