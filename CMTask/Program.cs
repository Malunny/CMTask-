// I will write here the engine that will run the application
using CMTask.Data;

InitialScreen initialScreen = new InitialScreen();

// Important things - Data accesser etc...

UIWritter uiWritter = new UIWritter();

// Other screens that I will use in the Engine

TaskScreen taskScreen = new TaskScreen(uiWritter);

bool isRunning = true;

while (isRunning)
{
    Console.Clear();

    // Menu part
    initialScreen.Show();
    char input = Console.ReadKey().KeyChar;

    switch (input)
    {
        case '1':
            Steps.Next = taskScreen.Show;
            
            break;
        case '0':
            isRunning = false;
            Console.SetCursorPosition(45, 16);
            continue;
        default:
            Console.SetCursorPosition(45, 11);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Invalid input! Please try again.");
            Console.SetCursorPosition(45, 12);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Press any key to continue...");
            Console.SetCursorPosition(45, 13);
            Console.ReadKey();
            continue;
    }

    Steps.Next?.Invoke();
}

internal static class Steps
{
    public static Action Next;
}
    