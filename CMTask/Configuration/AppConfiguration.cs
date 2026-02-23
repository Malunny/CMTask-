using CMTask.Data;

namespace TaskWorking.Configuration;

public static class AppConfiguration
{
    public static string AppDirectory { get; private set; } = (OperatingSystem.IsLinux())
                                                            ? $"/home/{Environment.UserName}/CMTaskFiles"
                                                            : "C:\\CMTaskFiles";
    public static string AppMainArchiveCsv { get; private set; }
    public static string AppMainArchiveXml { get; private set; }
    static AppConfiguration()
    {
        if(!Directory.Exists(AppDirectory))
            Directory.CreateDirectory(AppDirectory);

        //AppMainArchiveCsv = Path.Combine(AppDirectory, "main.csv");
        // if (!File.Exists(AppMainArchiveCsv))
        //    File.Create(AppMainArchiveCsv).Close();

        AppMainArchiveXml = Path.Combine(AppDirectory, "main.xml");
        if (!File.Exists(AppMainArchiveXml))
            File.Create(AppMainArchiveXml).Close();

        Console.SetWindowSize(125,20);
    }
}