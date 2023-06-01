namespace EventHub.Presentation.Common.Controls;

public class Menu
{
    private readonly List<MenuItem> items = new();

    public void AddMenuItem(MenuItem item, int? position = null)
    {
        if (position.HasValue)
        {
            if (position.Value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Position cannot be negative.");
            }

            items.Insert(position.Value, item);
        }
        else
        {
            items.Add(item);
        }
    }
    
    public void AddSeparator(int? position = null)
    {
        AddMenuItem(MenuItem.Separator(), position);
    }

    public void Display()
    {
        for (var i = 0; i < items.Count; i++)
        {
            if (items[i].IsSeparator)
            {
                Console.WriteLine("".PadRight(50, '-'));
                continue;
            }
            
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