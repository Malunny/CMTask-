using TaskWorking.Configuration;
using TaskWorking.Data;
using TaskWorking.Model;

namespace TaskWorking.Service.Paginators;

public static class FilesPaginator
{
    public static IEnumerable<IEnumerable<string>> Paginate(int pagination, string path)
    {
        ICollection<string> files = Directory.GetFiles(path);

        if (files.Count == 0)
            return new List<IEnumerable<string>>();

        List<IEnumerable<string>> paginatedTasks = new List<IEnumerable<string>>();

        int count = (files.Count % pagination != 0) ?
            (files.Count / pagination) + 1: (files.Count / pagination);

        int pagesLeft = files.Count;
        for (int i = 0; i < count; i++)
        {
            if (files.Count % pagination != 0 && pagesLeft / pagination < 1)
                paginatedTasks.Add(files.Skip
                    (i * pagination).Take(files.Count % pagination));
            else
            {
                paginatedTasks.Add(files.Skip
                    (i * pagination).Take(pagination));
                pagesLeft -= pagination;
            }
        }

        return paginatedTasks;
    }
}