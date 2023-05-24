namespace EventHub.Business.Reporting.UserStatistics;

public interface IUserStatisticUnit
{
    string Name { get; }

    DateTimeOffset OccurredAt { get; }
    
    UserStatisticAction Action { get; }
}