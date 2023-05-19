namespace EventHub.Presentation.Views.Controls;

public class Menu
{
    private readonly List<MenuItem> items = new();

    public void AddMenuItem(MenuItem item) => items.Add(item);
    
    public void Display()
    {
        for (var i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].Title}");
        }
    }

    public MenuItem GetSelectedMenuItem()
    {
        int choice;
        bool isValidChoice;

        do
        {
            Console.Write("Enter your choice: ");
            var input = Console.ReadLine();

            isValidChoice = int.TryParse(input, out choice) && choice >= 1 && choice <= items.Count;
            if (!isValidChoice)
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        } while (!isValidChoice);

        return items[choice - 1];
    }
}