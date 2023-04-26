using System.Text;

namespace MpsLabRefactor.Old;

public sealed class Client
{
    private readonly IList<Rent> rents = new List<Rent>();

    public required string Name { get; init; }

    public void AddRent(Rent rent)
    {
        rents.Add(rent);
    }

    public string Statement()
    {
        decimal totalAmount = 0;

        var frequentRenterPoints = 0;
        var result = new StringBuilder();

        result.AppendLine($"Registro de Alugueis de {Name}\n");

        foreach (var rent in rents)
        {
            decimal thisAmount = 0;

            switch (rent.Tape.PriceCode)
            {
                case PriceCode.Normal:
                    thisAmount += 2;
                    if (rent.Days > 2)
                    {
                        thisAmount += (rent.Days - 2) * 1.5m;
                    }

                    break;
                case PriceCode.Release:
                    thisAmount += rent.Days * 3;
                    break;
                case PriceCode.Children:
                    thisAmount += 1.5m;
                    if (rent.Days > 3)
                    {
                        thisAmount += (rent.Days - 3) * 1.5m;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            frequentRenterPoints++;

            if (rent.Tape.PriceCode == PriceCode.Release && rent.Days > 1)
            {
                frequentRenterPoints++;
            }

            result.AppendLine($"{rent.Tape.Title}\t{thisAmount}");

            totalAmount += thisAmount;
        }

        result.AppendLine($"\nValor total devido: {totalAmount}");
        result.AppendLine($"Voce acumulou {frequentRenterPoints} pontos de alugador frequente");

        return result.ToString();
    }
}