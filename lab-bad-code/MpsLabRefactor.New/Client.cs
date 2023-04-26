using MpsLabRefactor.New.Statement;

namespace MpsLabRefactor.New;

public sealed class Client
{
    private readonly IList<Rent> rents = new List<Rent>();

    public required string Name { get; init; }

    public void AddRent(Rent rent) => rents.Add(rent);

    public IReadOnlyList<Rent> Rents => rents.AsReadOnly();

    public string StatementAsText() => StatementFactory.CreateTextStatement(this).Generate();
    
    public string StatementAsHtml() => StatementFactory.CreateHtmlStatement(this).Generate();

    public decimal CalculateTotalCharge() => rents.Sum(rent => rent.CalculateCharge());

    public int CalculateTotalFrequentRenterPoints() => rents.Sum(rent => rent.CalculateFrequentRenterPoints());
}