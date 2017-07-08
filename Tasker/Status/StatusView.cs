using System;
using System.Collections.Generic;
using System.Linq;
using Tasker.Core;

namespace Tasker.Status
{
    public class StatusView
    {
        public TaskStatus Display(List<TaskStatus> statuses)
        {
            var statusesAsText = statuses.Select(ConvertStatusToText).ToList();
            for (var i = 0; i < statusesAsText.Count; i++)
            {
                Console.WriteLine($"{i + 1}). {statusesAsText[i]}");
            }
            var choice = Console.ReadLine();
            if (!Int32.TryParse(choice, out int option))
                return Display(statuses);
            if (option < 1 || option > statuses.Count)
                return Display(statuses);

            return statuses[option - 1];
        }

        private string ConvertStatusToText(TaskStatus status)
        {
            if (status == TaskStatus.ToDo)
                return "To Do";
            if (status == TaskStatus.InProgress)
                return "In Progress";
            if (status == TaskStatus.Done)
                return "Done";
            throw new ArgumentException("Don't know how to display a status of " + status);
        }
    }
}
