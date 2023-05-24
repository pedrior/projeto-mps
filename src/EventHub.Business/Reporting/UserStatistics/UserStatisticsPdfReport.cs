using System.Collections.Immutable;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace EventHub.Business.Reporting.UserStatistics;

public class UserStatisticsPdfReport : UserStatisticsReportTemplate
{
    private const string Filename = "user-statistics.pdf";
    private readonly PdfDocument document = new();

    public UserStatisticsPdfReport()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    protected override void WriteHeader()
    {
        var page = document.AddPage();
        var graphics = XGraphics.FromPdfPage(page);
        var font = new XFont("Verdana", 20, XFontStyle.Bold);

        DrawCenteredTitle(page, graphics, font, "User Statistics Report");
    }

    protected override void WriteBody(ImmutableList<IUserStatisticUnit> units)
    {
        var totalPages = units.Count / 10 + 1;

        var font = new XFont("Verdana", 10, XFontStyle.Regular);

        for (var i = 0; i < totalPages; i++)
        {
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            var pageUnits = units.Skip(i * 10).Take(10);

            var y = 0;

            foreach (var pageUnit in pageUnits)
            {
                gfx.DrawString(
                    text: $"[{pageUnit.Action} | {pageUnit.OccurredAt} – {pageUnit.Name}]",
                    font: font,
                    brush: XBrushes.Black,
                    layoutRectangle: new XRect(
                        x: 0,
                        y: y,
                        width: page.Width,
                        height: page.Height),
                    format: XStringFormats.TopLeft);

                y += 20;
            }

            gfx.DrawString(
                text: $"Page {i + 1} of {totalPages}",
                font: font,
                brush: XBrushes.Black,
                layoutRectangle: new XRect(
                    x: 0,
                    y: y,
                    width: page.Width,
                    height: page.Height),
                format: XStringFormats.TopLeft);
        }
    }

    protected override void WriteFooter()
    {
        var page = document.AddPage();
        var graphics = XGraphics.FromPdfPage(page);
        var font = new XFont("Verdana", 20, XFontStyle.Bold);

        DrawCenteredTitle(page, graphics, font, "End of User Statistics Report");
    }

    protected override void GenerateSpecificReportFormat()
    {
        document.Save(Filename);
        document.Close();
    }

    private static void DrawCenteredTitle(PdfPage page, XGraphics graphics, XFont font, string text) =>
        graphics.DrawString(
            text: text,
            font: font,
            brush: XBrushes.Black,
            layoutRectangle: new XRect(
                x: 0,
                y: 0,
                width: page.Width,
                height: page.Height),
            format: XStringFormats.Center);
}