namespace EventHub.Business.Reporting.UserStatistics;

public class UserRegisterStatisticUnit : IUserStatisticUnit
{
    public UserRegisterStatisticUnit(string username)
    {
        Name = username;
        OccurredAt = DateTimeOffset.Now;
    }
    
    public string Name { get; }
    
    public DateTimeOffset OccurredAt { get; }

    public UserStatisticAction Action => UserStatisticAction.Register;
}