using MpsLabRefactor.Old;

var client = new Client { Name = "Juliana" };

client.AddRent(new Rent { Days = 3, Tape = new Tape("O Exorcista", PriceCode.Normal) });
client.AddRent(new Rent { Days = 2, Tape = new Tape("Men in Black", PriceCode.Normal) });
client.AddRent(new Rent { Days = 3, Tape = new Tape("Jurassic Park III", PriceCode.Release) });
client.AddRent(new Rent { Days = 4, Tape = new Tape("Planeta dos Macacos", PriceCode.Release) });
client.AddRent(new Rent { Days = 10, Tape = new Tape("Pateta no Planeta dos Macacos", PriceCode.Children) });
client.AddRent(new Rent { Days = 30, Tape = new Tape("O Rei Leao", PriceCode.Children) });

Console.WriteLine(client.Statement());