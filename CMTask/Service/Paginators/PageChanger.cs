using System;
using System.Collections.Generic;
using System.Text;

namespace CMTask.Service.Paginators
{
    internal class PageManipulator(TasksPage pages, int currentPage = 1)
    {
        public int LastPage { get; private set; } = currentPage;
        public event Action<int>? OnGoToNextPage;
        public event Action<int>? OnGoPreviousPage;
        public readonly TasksPage Pages = pages;
        public bool CheckInput(string input)
        {
            if (input == "<")
            {
                if (LastPage != 1)
                    LastPage--;
                OnGoPreviousPage?.Invoke(LastPage);
                return true;
            }
            else if (input == ">")
            {
                if (Pages.Count > LastPage)
                    LastPage++;
                OnGoToNextPage?.Invoke(LastPage);
                return true;
            }
            return false;
        }
    }
}
