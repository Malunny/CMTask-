using CMTask.Data;
using CMTask.Service.ArchiveServices;
using TaskWorking.Service;

namespace CMTask.UI
{
    internal class TaskScreen(UIWritter uIWritter) : IShowable
    {
        private readonly UIWritter _uiWritter = uIWritter;
        private readonly TasksPage _tasksPage = new TasksPage(Path.Combine(AppConfiguration.AppMainArchiveXml), 5);
        private int PageNumber { get; set; } = 1;
        public void Show()
        {
            bool running = true;
            while (running)
            {
                _uiWritter.Clear();
                UICage.Create();

                // Repagination

                _tasksPage.RePaginate();

                //  Title

                _uiWritter.WriteOn("Your tasks:", 10, 2, ConsoleColor.Green);
                _uiWritter.WriteOn("-----------", 10, 3, ConsoleColor.White);

                if (_tasksPage != null && _tasksPage.Count != 0)
                {
                    var page = _tasksPage.Tasks.ElementAt(PageNumber - 1);

                    _uiWritter.WriteOn($"Page: {PageNumber} of {_tasksPage.Tasks.Count()}", 70, 2, ConsoleColor.White);

                    int i = 5;
                    foreach (var task in page)
                    {
                        _uiWritter.WriteOn($"ID - {task.Id}", 10, i, ConsoleColor.Yellow);
                        _uiWritter.WriteOn($"Title - {task.Title}", 20, i, ConsoleColor.White);
                        Console.ForegroundColor = ConsoleColor.White;
                        i++;
                    }
                }
                else
                {
                    Console.SetCursorPosition(10, 5);
                    Console.Write("There aren't tasks available.");
                }

                Console.SetCursorPosition(10, 13);
                Console.Write("----------------- press the task id number to select it -----------------");

                Console.SetCursorPosition(10, 14);
                _uiWritter.WriteOn("Press '<' or '>' to navigate through the pages. ", 10, 14, ConsoleColor.White);
                Console.Write("'c' to create a new task ");
                Console.Write("'0' to return.");

                Console.SetCursorPosition(10, 15);
                string input = Console.ReadLine() ?? "";

                switch (input)
                {
                    case "<":
                        if (PageNumber > 1)
                            PageNumber--;
                        break;
                    case ">":
                        if (PageNumber < _tasksPage.Count)
                            PageNumber++;
                        break;
                    case "c":
                        running = false;
                        TaskWriterXml archiveWriter = new TaskWriterXml();
                        archiveWriter.WriteOn(new XmlDataSaver(), new XmlDataAccesser());
                        break;
                    default:
                        var inputId = TryCatchIntConverter.ConvertStringToInt(input.ToString());
                        if (inputId == 0)
                        {
                            running = false;
                            break;
                        }

                        ToDoTask? task = null;

                        if (_tasksPage.Tasks.Any())
                            task = _tasksPage?.Tasks.ElementAt(PageNumber - 1)
                                                    .Where(x => x.Id == inputId).FirstOrDefault();
                        if (inputId != -1 && task != null && inputId > 0)
                        {
                            new TaskDetailsScreen(task, _uiWritter).Show();
                        }
                        else
                        {
                            Console.SetCursorPosition(10, 15);
                            Console.Write("> ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Invalid input! Please try again.");
                            Console.SetCursorPosition(46, 15);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Press any key to continue...");
                            Console.SetCursorPosition(90, 15);
                            Console.ReadKey();
                        }
                        break;
                }
            }
        }
    }
}
