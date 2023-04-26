using System.Text;

namespace MpsLabRefactor.New.Statement;

public abstract class Statement
{
    private readonly StringBuilder result = new();

    protected Statement(Client client)
    {
        Client = client;
    }

    protected Client Client { get; }

    public string Generate()
    {
        var builder = new StringBuilder();

        WriteHeader(builder);

        foreach (var rent in Client.Rents)
        {
            WriteDetail(builder, rent);
        }

        WriteFooter(builder);

        return builder.ToString();
    }

    protected abstract void WriteHeader(StringBuilder builder);

    protected abstract void WriteDetail(StringBuilder builder, Rent rent);

    protected abstract void WriteFooter(StringBuilder builder);
}