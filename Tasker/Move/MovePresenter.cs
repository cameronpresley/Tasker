using Tasker.DataAccess;
using Tasker.Status;
using Task = Tasker.Core.Task;

namespace Tasker.Move
{
    public class MovePresenter
    {
        private readonly IRepository<Task> _taskRepo;

        public MovePresenter(IRepository<Task> taskRepo)
        {
            _taskRepo = taskRepo;
        }
        public void Execute()
        {
            // Show Tasks to User
            // Let User Pick Task by Id
            // Let User Choose New Status (Ideally by numeric option...
            // Edit the Task
            // Save changes to the Repo
            var task = new DisplayTaskView(_taskRepo.GetAll()).Display();
            var status = new StatusPresenter().Execute();

            task.Status = status;
            _taskRepo.Update(task);
        }
    }
}
