using MpsLabRefactor.New.Pricing;

namespace MpsLabRefactor.New;

public sealed class Tape
{
    private Price price;

    public Tape(string title, PriceCode priceCode)
    {
        Title = title;
        price = PriceFactory.Create(priceCode);
    }

    public string Title { get; }
    
    public PriceCode PriceCode => price.Code;

    public void SetPrice(PriceCode code) => price = PriceFactory.Create(code);
    
    public decimal CalculateCharge(int daysRented) => price.CalculateCharge(daysRented);
    
    public int CalculateFrequentRenterPoints(int daysRented) => price.CalculateFrequentRenterPoints(daysRented);
}