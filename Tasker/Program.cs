using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Add;
using Tasker.DataAccess;
using Tasker.Move;

namespace Tasker
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskRepo = new TaskRepository();
            var addPresenter = new AddPresenter(taskRepo);
            var movePresenter = new MovePresenter(taskRepo);
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
                    case UserCommand.MoveTask:
                        movePresenter.Execute();
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
            Console.WriteLine("To quit, choose \"2\" or \"quit\"");
        }

        private static void PrintOptions()
        {
            var options = new List<string>
            {
                "Add a task",
                "Move task",
                "Quit"
            };

            Console.WriteLine("What would you like to do?");
            for (var i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i+1}). {options[i]}");
            }
        }
    }
}
