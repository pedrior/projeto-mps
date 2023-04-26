namespace MpsLabRefactor.New.Pricing;

public sealed class ChildrenPrice : Price
{
    public override PriceCode Code => PriceCode.Children;

    public override decimal CalculateCharge(int daysRented)
    {
        var result = 1.5m;
        if (daysRented > 3)
        {
            result += (daysRented - 3) * 1.5m;
        }

        return result;
    }
}