using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Move;
using TaskStatus = Tasker.Core.TaskStatus;

namespace Tasker.Status
{
    public class StatusPresenter
    {
        private readonly List<TaskStatus> _statuses;

        public StatusPresenter()
        {
            _statuses = new List<TaskStatus>
            {
                TaskStatus.ToDo,
                TaskStatus.InProgress,
                TaskStatus.Done
            };
        }

        public TaskStatus Execute()
        {
            return new StatusView().Display(_statuses);
        }
    }
}
