namespace EventHub.Business.Facades;

public interface ICommand
{
    void Execute();
}

public interface ICommand<in TRequest>
{
    void Execute(TRequest request);
}

public interface ICommand<in TRequest, out TResponse>
{
    TResponse Execute(TRequest request);
}