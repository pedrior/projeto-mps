namespace MpsLabRefactor.New.Statement;

public static class StatementFactory
{
    public static Statement CreateTextStatement(Client client) => new TextStatement(client);

    public static Statement CreateHtmlStatement(Client client) => new HtmlStatement(client);
}