namespace MpsLabRefactor.New;

public sealed class Rent
{
    public required Tape Tape { get; init; }

    public required int Days { get; init; }

    public decimal CalculateCharge() => Tape.CalculateCharge(Days);

    public int CalculateFrequentRenterPoints() => Tape.CalculateFrequentRenterPoints(Days);
}