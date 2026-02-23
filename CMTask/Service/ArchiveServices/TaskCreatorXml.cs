using System;
using System.Collections.Generic;
using System.Text;

namespace CMTask.Service.ArchiveServices
{
    internal class TaskCreatorXml : IArchiveCreator
    {
        public void CreateArchivePrompt()
        {
            bool continueToTry = true;
            while (continueToTry)
            {
                Console.Clear();
                UICage.Create();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(10, 2);
                Console.Write("- Task Creator Mode -");
                Console.SetCursorPosition(10, 3);
                Console.Write("---------------------");
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(10, 5);
                Console.Write("Type the archive name to be created: ");

                Console.SetCursorPosition(10, 6);
                Console.Write("-> ");
                string? archiveName = Console.ReadLine();

                CheckArchiveName(archiveName, ref continueToTry);

                CreateTask(archiveName, ref continueToTry);

            }
            Console.Clear();
        }

        private void CheckArchiveName(string? archiveName, ref bool continueToTry)
        {
            if (string.IsNullOrEmpty(archiveName?.Trim()))
            {
                Console.WriteLine("You wrote something wrong." +
                                  Environment.NewLine
                                  + "Press any key to continue...");
                Console.ReadKey();
                continueToTry = true;
            }
            else
                continueToTry = false;
        }

        private void CreateTask(string archiveName, ref bool continueToTry)
        {
            string filePath = Path.Combine(AppConfiguration.AppDirectory, $"{archiveName}.csv");

            if (continueToTry)
                return;

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                Console.WriteLine($"Archive - {archiveName}.csv successfully created!");
                Console.ReadKey();
                continueToTry = false;
            }
            else
            {
                Console.WriteLine("An archive already holds this name.");
                Console.WriteLine("Press any key to retry...");
                Console.ReadKey();
                continueToTry = true;
            }
        }
    }
}
