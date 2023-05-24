namespace EventHub.Business.Reporting.UserStatistics;

public class UserLoginStatisticUnit : IUserStatisticUnit
{
    public UserLoginStatisticUnit(string username)
    {
        Name = username;
        OccurredAt = DateTimeOffset.Now;
    }
    
    public string Name { get; }
    
    public DateTimeOffset OccurredAt { get; }

    public UserStatisticAction Action => UserStatisticAction.Login;
}