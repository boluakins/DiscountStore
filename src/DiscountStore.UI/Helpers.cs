using System;

namespace DiscountStore.UI
{
    public static class Helpers
    {
        public static void SetViewName(string name)
        {
            Console.WriteLine("=======================");
            Console.WriteLine($"     { name}");
            Console.WriteLine("=======================");
        }

        public static void MenuPrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Select another option from Menu");
            Console.WriteLine();
        }
    }
}
