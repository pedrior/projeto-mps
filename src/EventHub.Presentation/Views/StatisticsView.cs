using EventHub.Business.Controllers;
using EventHub.Presentation.Views.Controls;
using EventHub.Presentation.Views.Internal;

namespace EventHub.Presentation.Views;

public sealed class StatisticsView : NavigationView
{
    private readonly MenuBuilder menuBuilder = new();
    private readonly UserController userController;

    public StatisticsView(IView ancestor, UserController userController) : base(ancestor)
    {
        this.userController = userController;
    }

    public override string Title => "Statistics";

    protected override Menu CreateMenu()
    {
        return menuBuilder
            .AddMenuItem("Generate User Statistics in HTML", GenerateUserStatisticsInHtml)
            .AddMenuItem("Generate User Statistics in PDF", GenerateUserStatisticsInPdf)
            .AddMenuItem("Back", GoBack)
            .Build();
    }

    private void GenerateUserStatisticsInHtml()
    {
        userController.GenerateHtmlUserStatisticsReport();
        Console.WriteLine("User statistics report generated in HTML format.\n");
    }

    private void GenerateUserStatisticsInPdf()
    {
        userController.GeneratePdfUserStatisticsReport();
        Console.WriteLine("User statistics report generated in PDF format.\n");
    }

    private void GoBack() => Navigator.Back(this);
}