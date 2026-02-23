using CMTask.Data;
using TaskWorking.Configuration;
using TaskWorking.Data;
using TaskWorking.Model;

namespace TaskWorking.Service;

public class TasksPaginator : IPaginator<ToDoTask>
{
    public IEnumerable<IEnumerable<ToDoTask>> Paginate(int pagination, string path)
    {
        XmlDataAccesser xmlDataAccess = new XmlDataAccesser();

        ICollection<ToDoTask> tasks = xmlDataAccess.GetData() 
            as ICollection<ToDoTask> ?? new List<ToDoTask>();

        List<IEnumerable<ToDoTask>> paginatedTasks = new List<IEnumerable<ToDoTask>>();

        int count = (tasks.Count % pagination != 0) ?
            (tasks.Count / pagination) + 1 : (tasks.Count / pagination);

        int pagesLeft = tasks.Count;
        for (int i = 0; i < count; i++)
        {
            if (tasks.Count % pagination != 0 && pagesLeft / pagination < 1)
                paginatedTasks.Add(tasks.Skip
                    (i * pagination).Take(tasks.Count % pagination));
            else
            {
                paginatedTasks.Add(tasks.Skip
                    (i * pagination).Take(pagination));
                pagesLeft -= pagination;
            }
        }
        
        return paginatedTasks;
    }
}