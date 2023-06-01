using EventHub.Presentation.Common.Controls;

namespace EventHub.Presentation.Common.Views;

public abstract class View : IView
{
    private Menu? menu;

    public abstract string Title { get; }

    protected abstract Menu BuildMenu();
    
    protected virtual void BuildContent()
    {
    }
    
    protected void Reshow()
    {
        Console.Clear();
        
        InvalidateMenu();
        Show();
    }
    
    public void InvalidateMenu() => menu = null;

    public void Show()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Title}\n");
        Console.ResetColor();
        
        BuildContent();
        
        menu ??= BuildMenu();
        
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