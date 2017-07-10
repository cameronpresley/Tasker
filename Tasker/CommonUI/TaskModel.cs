using System;
using System.Linq;
using Task = Tasker.Core.Task;
using TaskStatus = Tasker.Core.TaskStatus;

namespace Tasker.CommonUI
{
    public class TaskModel
    {
        private readonly Task _task;

        public string Id => _task.Id.ToString();
        public string Title => String.Join("", _task.Title.Take(20));
        public string Description => String.Join("", _task.Description.Take(30));
        public string Status => ConvertStatus(_task.Status);

        public TaskModel(Task task)
        {
            _task = task ?? throw new ArgumentNullException(nameof(task));
        }

        private string ConvertStatus(TaskStatus status)
        {
            switch (status)
            {
                case TaskStatus.ToDo:
                    return "To Do";
                case TaskStatus.InProgress:
                    return "In Progress";
                case TaskStatus.Done:
                    return "Done";
                case TaskStatus.Unknown:
                    throw new ArgumentException("Status is unknown.");
                default:
                    throw new ArgumentOutOfRangeException("Don't know how to deal with a status of " + _task.Status);
            }
        }
    }
}
