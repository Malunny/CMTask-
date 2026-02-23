using System;
using System.Collections.Generic;
using System.Text;
using TaskWorking.Service;
using TaskWorking.Service.Paginators;

namespace CMTask.Service.Paginators
{
    internal class TasksPage
    {
        public IEnumerable<IEnumerable<ToDoTask>> Tasks { get; private set; }
        public int Count { get; private set; }

        private (string _path, int _taskPerPage) _paginationInfo;
        public TasksPage(string path, int taskPerPage)
        {
            Tasks = new TasksPaginator().Paginate(taskPerPage, path);
            Count = Tasks.Count();

            _paginationInfo = (path, taskPerPage);
        }

        public void RePaginate()
        {
            Tasks = new TasksPaginator().Paginate(_paginationInfo._taskPerPage, _paginationInfo._path);
            Count = Tasks.Count();
        }
    }
}
