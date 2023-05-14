using System.Reflection;

namespace EventHub.Infrastructure.Persistence.Context.JsonDb;

public sealed class JsonDbContext : DbContext
{
    private readonly Dictionary<Type, object> sets = new();

    internal JsonDbContext()
    {
    }

    internal override DbSet<T> Set<T>() where T : class
    {
        if (sets.TryGetValue(typeof(T), out var value))
        {
            return (DbSet<T>)value;
        }

        var set = File.Exists(JsonDbSetSerializer<T>.GetFilePath())
            ? JsonDbSetSerializer<T>.LoadFromJson()
            : new DbSet<T>();

        sets[typeof(T)] = set;
        return set;
    }

    public override void SaveChanges()
    {
        var methods = sets
            .Select(s => typeof(JsonDbSetSerializer<>)
                .MakeGenericType(s.Key)
                .GetMethod(nameof(JsonDbSetSerializer<object>.SaveToJson), BindingFlags.Public | BindingFlags.Static))
            .Where(m => m is not null);

        Parallel.ForEach(methods, method =>
        {
            method!.Invoke(null, new[]
            {
                sets[method.GetParameters()[0].ParameterType.GenericTypeArguments[0]]
            });
        });
    }
}