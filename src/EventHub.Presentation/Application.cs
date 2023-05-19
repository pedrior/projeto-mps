using EventHub.Presentation.Views.Internal;

namespace EventHub.Presentation;

public static class Application
{
    public static void Run(IView root) => root.Show();

    public static void Shutdown() => Environment.Exit(0);
}