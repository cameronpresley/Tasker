using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Tasker.Core.Task;

namespace Tasker.Move
{
    public class DisplayTaskView
    {
        private readonly IEnumerable<Task> _tasks;
        private int _currentIndex;
        private readonly int _maxIndex;
        public DisplayTaskView(IEnumerable<Task> tasks)
        {
            _tasks = tasks;
            _currentIndex = 0;
            _maxIndex = _tasks.Count() / 10;
        }

        public Task Display()
        {
            var beginningCount = 10 * _currentIndex + 1;
            var endingCount = beginningCount + 10;
            var totalCount = _tasks.Count();
            Console.WriteLine("Displaying " + beginningCount + "-" + endingCount + " of " + totalCount);
            var tasksToDisplay = _tasks.Skip(10 * _currentIndex).Take(10).ToList();
            foreach (var t in tasksToDisplay)
            {
                Console.WriteLine($"{t.Id}). {t.Status} - {t.Title}");
            }
            DisplayUserOptions();
            var input = Console.ReadLine().ToLower();
            if (input == "more" && _currentIndex != _maxIndex)
            {
                _currentIndex++;
                return Display();
            }
            var possibleTask = tasksToDisplay.Where(x => x.Id.ToString() == input).ToList();
            if (possibleTask.Any())
                return possibleTask.First();
            return Display();
        }

        public void DisplayUserOptions()
        {
            Console.WriteLine("Choose a task to move.");
            Console.WriteLine("Type 'more' to see additional tasks");
        }
    }
}
