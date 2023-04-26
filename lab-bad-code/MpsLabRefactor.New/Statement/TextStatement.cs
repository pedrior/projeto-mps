using System.Text;

namespace MpsLabRefactor.New.Statement;

public sealed class TextStatement : Statement
{
    public TextStatement(Client client) : base(client)
    {
    }

    protected override void WriteHeader(StringBuilder builder) =>
        builder.AppendLine($"Registro de Alugueis de {Client.Name}\n");

    protected override void WriteDetail(StringBuilder builder, Rent rent) =>
        builder.AppendLine($"{rent.Tape.Title}\t{rent.CalculateCharge()}");

    protected override void WriteFooter(StringBuilder builder)
    {
        builder.AppendLine($"Total: {Client.CalculateTotalCharge()}");
        builder.AppendLine($"Pontos de Alugador Frequente: {Client.CalculateTotalFrequentRenterPoints()}");
    }
}