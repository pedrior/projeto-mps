using System.Collections.Immutable;
using System.Text;

namespace EventHub.Business.Reporting.UserStatistics;

public class UserStatisticsHtmlReport : UserStatisticsReportTemplate
{
    private const string Filename = "user-statistics.html";

    protected override void WriteHeader()
    {
        Report.AppendLine("<h1>User Statistics Report</h1>");
        Report.AppendLine("<hr/>");
    }

    protected override void WriteBody(ImmutableList<IUserStatisticUnit> units)
    {
        Report.AppendLine("<table>");
        Report.AppendLine("<tr>");
        Report.AppendLine("<th>User</th>");
        Report.AppendLine("<th>Access Count</th>");
        Report.AppendLine("</tr>");

        foreach (var unit in units)
        {
            Report.AppendLine("<tr>");
            Report.AppendLine($"<td>[{unit.Action} | {unit.OccurredAt} – {unit.Name}]</td>");
            Report.AppendLine($"<td>{units.Count}</td>");
            Report.AppendLine("</tr>");
        }

        Report.AppendLine("</table>");
    }

    protected override void WriteFooter()
    {
        Report.AppendLine("<hr/>");
        Report.AppendLine("<p>End of User Statistics Report</p>");
    }

    protected override void GenerateSpecificReportFormat() =>
        File.WriteAllText(Filename, Report.ToString(), Encoding.UTF8);
}