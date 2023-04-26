namespace MpsLabRefactor.New.Pricing;

public sealed class RegularPrice : Price
{
    public override PriceCode Code => PriceCode.Regular;
    
    public override decimal CalculateCharge(int daysRented)
    {
        var result = 2m;
        if (daysRented > 2)
        {
            result += (daysRented - 2) * 1.5m;
        }

        return result;
    }
}