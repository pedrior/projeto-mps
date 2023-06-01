namespace EventHub.Presentation.Common;

internal static class ConsoleHelper
{
    public static string ReadRequiredString(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt}: ");
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            Console.WriteLine("Please enter a value.");
        }
    }

    public static bool ReadYesNo(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt} (y/n): ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "y" or "Y":
                    return true;
                case "n" or "N":
                    return false;
                default:
                    Console.WriteLine("Please enter y or n.");
                    break;
            }
        }
    }
}