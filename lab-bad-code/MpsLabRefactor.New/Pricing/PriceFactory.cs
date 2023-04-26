namespace MpsLabRefactor.New.Pricing;

public static class PriceFactory
{
    public static Price Create(PriceCode code) => code switch
    {
        PriceCode.Regular => new RegularPrice(),
        PriceCode.NewRelease => new NewReleasePrice(),
        PriceCode.Children => new ChildrenPrice(),
        _ => throw new ArgumentException($"Unknown price code: {code}")
    };
}