using System;

namespace Tasker.Add
{
    public class AddView
    {
        public AddModel Display()
        {
            bool TitleValidtor(string s) => !String.IsNullOrWhiteSpace(s);
            bool DescValidator(string s) => !String.IsNullOrWhiteSpace(s);
            var model = new AddModel
            {
                Title = GetValidInput("What's the title?", "Title must be specified", TitleValidtor),
                Description = GetValidInput("What's the description?", "Description must be specified", DescValidator),
            };
            return model;
        }

        private string GetValidInput(string prompt, string errorPrompt, Func<string, bool> validator)
        {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();
            if (validator(input))
                return input;

            Console.WriteLine(errorPrompt);
            return GetValidInput(prompt, errorPrompt, validator);
        }
    }
}
