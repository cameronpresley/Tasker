using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Tasker.Core;

namespace Tasker.CommonUI
{
    public class TaskView
    {
        public Task SelectedTask { get; set; }
        private readonly TaskPresenter _presenter;

        public TaskView(TaskPresenter presenter)
        {
            _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        }

        public void Display()
        {
            Console.Clear();
            DisplayDescriptor(_presenter.TasksToShow);
            DisplayTable(_presenter.TasksToShow);

            var input = Console.ReadLine().ToLower();
            HandleInput(input);
        }


        private void HandleInput(string input)
        {
            switch (input)
            {
                case "more":
                    _presenter.MoreCommand();
                    Display();
                    break;
                case "less":
                    _presenter.LessCommand();
                    Display();
                    break;
                default:
                    var possibleTask = _presenter.TasksToShow.Where(x => x.Id.ToString() == input).ToList();
                    if (!possibleTask.Any())
                        Display();
                    else
                        _presenter.SelectTask(possibleTask.First());
                    break;
            }
        }

        private static void DisplayTable(List<TaskModel> tasks)
        {
            Console.WriteLine("ID, Title, Status, Desc");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.Id}). {task.Title} = {task.Status} = {task.Description}");
            }
        }

        private void DisplayDescriptor(List<TaskModel> tasksToShow)
        {
            var start = _presenter.CurrentPage * TaskPresenter.MaxToShowOnScreen + 1;
            var last = start + tasksToShow.Count - 1;
            Console.WriteLine($"Displaying {start}-{last}");
        }
    }
}
