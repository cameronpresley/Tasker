﻿using System.Collections.Generic;
using System.Linq;
using Task = Tasker.Core.Task;

namespace Tasker.CommonUI
{
    public class TaskPresenter
    {
        public const int MaxToShowOnScreen = 10;
        private readonly List<Task> _tasks;
        private readonly int _numberOfPages;

        public Task SelectedTask { get; private set; }

        public int CurrentPage { get; private set; }

        public List<TaskModel> TasksToShow
        {
            get
            {
                return _tasks
                    .Skip(CurrentPage * MaxToShowOnScreen)
                    .Take(MaxToShowOnScreen)
                    .Select(x => new TaskModel(x))
                    .ToList();
            }
        }

        public TaskPresenter(List<Task> tasks)
        {
            _tasks = tasks;
            _numberOfPages = CalculateNumberOfPages();
        }

        private int CalculateNumberOfPages()
        {
            var pages = _tasks.Count / MaxToShowOnScreen;
            var isThereARoundNumberOfTasks = _tasks.Count % MaxToShowOnScreen == 0;
            return isThereARoundNumberOfTasks ? pages - 1 : pages;
        }

        public void MoreCommand()
        {
            if (CurrentPage < _numberOfPages)
                CurrentPage++;
        }

        public void LessCommand()
        {
            if (CurrentPage > 0)
                CurrentPage--;
        }

        public void SelectTask(TaskModel model)
        {
            SelectedTask = _tasks.First(x => x.Id.ToString() == model.Id);
        }
    }
}