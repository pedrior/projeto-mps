namespace MpsLabRefactor.Old;

public sealed class Tape
{
    public Tape(string title, PriceCode priceCode)
    {
        Title = title;
        PriceCode = priceCode;
    }

    public string Title { get; init; }

    public PriceCode PriceCode { get; set; }
}