using System.Text;

namespace MpsLabRefactor.New.Statement;

public sealed class HtmlStatement : Statement
{
    public HtmlStatement(Client client) : base(client)
    {
    }

    protected override void WriteHeader(StringBuilder builder)
    {
        builder.AppendLine($"<h1>Registro de Alugueis de {Client.Name}</h1>\n");
    }

    protected override void WriteDetail(StringBuilder builder, Rent rent)
    {
        builder.AppendLine($"<p>{rent.Tape.Title}: {rent.CalculateCharge()}</p>");
    }

    protected override void WriteFooter(StringBuilder builder)
    {
        builder.AppendLine($"<p>Total: {Client.CalculateTotalCharge()}</p>");
        builder.AppendLine($"<p>Pontos de Alugador Frequente: {Client.CalculateTotalFrequentRenterPoints()}</p>");
    }
}