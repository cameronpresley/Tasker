using System;

namespace Tasker
{
    public static class InputToUserCommandConverter
    {
        public static UserCommand Convert(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            switch (input.ToLower())
            {
                case "add":
                case "1":
                    return UserCommand.AddTask;
                case "show":
                case "2":
                    return UserCommand.ShowTasks;
                case "quit":
                case "3":
                    return UserCommand.Quit;
                default:
                    return UserCommand.Unknown;
            }
        }
    }
}
