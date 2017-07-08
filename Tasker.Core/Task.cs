using System;

namespace Tasker.Core
{
    public class Task
    {
        public string Title { get; }
        public string Description { get; }
        public TaskStatus Status { get; }
        public readonly int Id;

        private Task(int id, string title, string description, TaskStatus status)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
        }

        public static Task Create(string title, string description)
        {
            if (String.IsNullOrWhiteSpace(title)) throw new ArgumentException(nameof(title) + " must be specified");
            if (String.IsNullOrWhiteSpace(description)) throw new ArgumentException(nameof(description) + " must be specified");
            return new Task(-1, title, description, TaskStatus.ToDo);
        }
    }
}
