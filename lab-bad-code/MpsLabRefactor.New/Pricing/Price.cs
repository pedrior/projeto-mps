namespace MpsLabRefactor.New.Pricing;

public abstract class Price
{
    public abstract PriceCode Code { get; }

    public abstract decimal CalculateCharge(int daysRented);

    public virtual int CalculateFrequentRenterPoints(int daysRented) => 1;
}