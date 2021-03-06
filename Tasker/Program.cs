﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Add;
using Tasker.DataAccess;

namespace Tasker
{
    class Program
    {
        static void Main(string[] args)
        {
            var addPresenter = new AddPresenter(new TaskRepository());
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
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1). Add a task");
            Console.WriteLine("2). Quit");
        }
    }
}
