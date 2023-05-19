using EventHub.Presentation.Views.Controls;

namespace EventHub.Presentation.Views.Internal;

public abstract class View : IView
{
    private Menu? menu;

    public abstract string Title { get; }

    protected abstract Menu CreateMenu();
    
    protected virtual void CreateContent()
    {
    }

    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Title}\n");
        Console.ResetColor();

        CreateContent();
        
        menu ??= CreateMenu();

        while (true)
        {
            menu.Display();
            menu.GetSelectedMenuItem()
                .Action();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.ResetColor();
        }

        // ReSharper disable once FunctionNeverReturns
    }
}