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
                case "move":
                case "2":
                    return UserCommand.MoveTask;
                case "3":
                case "quit":
                    return UserCommand.Quit;
                default:
                    return UserCommand.Unknown;
            }
        }
    }
}
