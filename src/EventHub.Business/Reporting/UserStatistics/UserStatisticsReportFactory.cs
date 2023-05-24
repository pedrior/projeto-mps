namespace EventHub.Business.Reporting.UserStatistics;

public static class UserStatisticsReportFactory
{
    public static UserStatisticsReportTemplate CreateReport(ReportFormat format) => format switch
    {
        ReportFormat.Html => new UserStatisticsHtmlReport(),
        ReportFormat.Pdf => new UserStatisticsPdfReport(),
        _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
    };
}