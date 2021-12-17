using System;

namespace Application.Commons.Helpers
{
    public static class Utilities
    {
        public static string ValidateUserInput()
        {
            // ensures user input is not null and empty
            Console.WriteLine("Enter choice: ");
            string input = GetUserInput();
            if (input == ExitCode)
            {
                Console.WriteLine();
                Console.WriteLine("You have exited the application. Goodbye..");
                Environment.Exit(0);
            }
            if (input == MenuCode)
            {
                input = "Menu";
            }
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Field can't be empty\nTry again: ");
                input = Console.ReadLine();
            }
            return input;
        }
        public static string ValidateUserInput(string message)
        {
            // overload, prompt is dynamic. ensures user input is not null and empty
            Console.WriteLine($"{message}: ");
            string input = GetUserInput();
            if (input == ExitCode)
            {
                Console.WriteLine();
                Console.WriteLine("You have exited the application. Goodbye..");
                Environment.Exit(0);
            }
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Field can't be empty\nTry again: ");
                input = Console.ReadLine();
            }
            return input;
        }

        private static string GetUserInput()
        {
            return Console.ReadLine().Trim();
        }

        public static string ExitApplication()
        {
            //exit application prompt
            return $"{ExitCode}: Exit the application";
        }
        public static string ReturnToMenu()
        {
            //escape to menu prompt
            return $"{MenuCode}: Return to Menu";
        }

    }
}
