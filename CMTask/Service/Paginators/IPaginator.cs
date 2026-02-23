namespace TaskWorking.Service;

public interface IPaginator<T>
{
    IEnumerable<IEnumerable<T>> Paginate(int pagination, string path);
}
