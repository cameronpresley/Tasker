using System;
using Tasker.Core;
using Tasker.DataAccess;

namespace Tasker.Add
{
    public class AddPresenter
    {
        private readonly IRepository<Task> _repo;
        public AddPresenter(IRepository<Task> repo)
        {
            _repo = repo;
        }
        public void Execute()
        {
            var view = new AddView();
            var record = view.Display();
            try
            {
                var model = Task.Create(record.Title, record.Description);
                _repo.Add(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create model " + ex.Message);   
            }
        }
    }
}
