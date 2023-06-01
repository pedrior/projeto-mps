using EventHub.Presentation.Common.Views;

namespace EventHub.Presentation.Common;

public static class Application
{
    public static void Run(IView root) => root.Show();

    public static void Shutdown() => Environment.Exit(0);
}