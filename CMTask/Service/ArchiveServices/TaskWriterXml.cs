using System;
using System.Collections.Generic;
using System.Text;
using CMTask.Data;
using CMTask.UI;
using TaskWorking.Data;

namespace CMTask.Service.ArchiveServices
{
    internal class TaskWriterXml : IDataWriter
    {
        private TaskCreationScreen _taskCreationScreen = new TaskCreationScreen();
        public void WriteOn(IDataSaver xmlDataSaver, IDataAcess xmlDataAccess)
        {
            xmlDataAccess = xmlDataAccess as XmlDataAccesser;
            ArgumentNullException.ThrowIfNull(xmlDataAccess, nameof(xmlDataAccess));

            xmlDataSaver = xmlDataSaver as XmlDataSaver;
            ArgumentNullException.ThrowIfNull(xmlDataSaver, nameof(xmlDataSaver));

            string path = AppConfiguration.AppMainArchiveXml;

            _taskCreationScreen.Show();

            string[,] nowTask = new string[3, 2];

            int idNumerator = (xmlDataAccess.GetData().Count()) == 0 ? 1
                             : xmlDataAccess.GetData().Count() + 1;

            nowTask[0, 0] = "Id";
            nowTask[1, 0] = "Title";
            nowTask[2, 0] = "Description";

            bool continuing = true;

            while (true)
            {
                for (int i = 1; i < 3; i++)
                {
                    Console.Clear();
                    _taskCreationScreen.Show();

                    Console.SetCursorPosition(10, 5);
                    Console.Write("Write and enter -0 to exit this mode.");
                    Console.SetCursorPosition(10, 6);
                    Console.Write($"Id: {idNumerator} | Título: {nowTask[1, 1]} ");
                    Console.SetCursorPosition(10, 7);
                    Console.Write($"|- Description: {nowTask[2, 1]}");
                    Console.SetCursorPosition(10, 11);
                    Console.Write($"Write and enter the value of: {nowTask[i, 0]}:");

                    nowTask[i, 1] = Console.ReadLine() ?? "Null";

                    if (nowTask[i, 1] == "-0")
                    {
                        continuing = false;
                        break;
                    }
                }
                if (!continuing)
                    break;
                xmlDataSaver.SaveData(new ToDoTask { Id = idNumerator, Title = nowTask[1, 1], Description = nowTask[2, 1] });
                idNumerator++;
                nowTask[1, 1] = "";
                nowTask[2, 1] = "";
            }
        }
    }
}
