namespace MpsLabRefactor.New.Pricing;

public sealed class NewReleasePrice : Price
{
    public override PriceCode Code => PriceCode.NewRelease;
    
    public override decimal CalculateCharge(int daysRented) => daysRented * 3;

    public override int CalculateFrequentRenterPoints(int daysRented) => daysRented > 1 ? 2 : 1;
}