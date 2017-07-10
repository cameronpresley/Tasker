using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Add;
using Tasker.CommonUI;
using Tasker.DataAccess;
using Task = Tasker.Core.Task;

namespace Tasker
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new TaskRepository();
            Enumerable
                .Range(1, 21)
                .Select(index => Task.Create("Title #" + index, "Description"))
                .Select(repo.Add).ToList();

            var addPresenter = new AddPresenter(repo);
            UserCommand command;
            do
            {
                PrintOptions();
                command = InputToUserCommandConverter.Convert(Console.ReadLine());
                switch (command)
                {
                    case UserCommand.AddTask:
                        addPresenter.Execute();
                        break;
                    case UserCommand.ShowTasks:
                        var presenter = new TaskPresenter(repo.GetAll().ToList());
                        var view = new TaskView(presenter);
                        view.Display();
                        var selection = presenter.SelectedTask;
                        break;
                    case UserCommand.Quit:
                        break;
                    case UserCommand.Unknown:
                        PrintErrorMessage();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } while (command != UserCommand.Quit);
        }

        private static void PrintErrorMessage()
        {
            Console.WriteLine("Invalid input:");
            Console.WriteLine("To add a task, choose \"1\" or \"add\"");
            Console.WriteLine("To show all tasks, choose \"2\" or \"show\"");
            Console.WriteLine("To quit, choose \"3\" or \"quit\"");
        }

        private static void PrintOptions()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1). Add a task");
            Console.WriteLine("2). Show Tasks");
            Console.WriteLine("3). Quit");
        }
    }
}
