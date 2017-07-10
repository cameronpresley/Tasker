using System.Collections.Generic;
using System.Linq;
using Tasker.Core;

namespace Tasker.DataAccess
{
    public class TaskRepository :IRepository<Task>
    {
        private readonly List<Task> _tasks;

        public TaskRepository()
        {
            _tasks = new List<Task>();    
        }
        public Task Add(Task record)
        {
            record.Id = CalculateId();
            _tasks.Add(record);
            return record;
        }

        public IEnumerable<Task> GetAll()
        {
            return new List<Task>(_tasks);
        }

        private int CalculateId()
        {
            if (!_tasks.Any()) return 0;
            return _tasks.Max(x => x.Id) + 1;
        }
    }
}
