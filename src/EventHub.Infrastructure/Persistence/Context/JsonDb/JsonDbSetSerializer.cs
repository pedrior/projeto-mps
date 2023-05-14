using System.Text;
using Newtonsoft.Json;

namespace EventHub.Infrastructure.Persistence.Context.JsonDb;

internal static class JsonDbSetSerializer<T> where T : class
{
    private const string BaseFileName = "data.{name}.json";

    public static DbSet<T> LoadFromJson()
    {
        var path = GetFilePath();
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File not found", path);
        }

        var json = File.ReadAllText(path, Encoding.UTF8);
        var entities = JsonConvert.DeserializeObject<IEnumerable<T>>(json, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        }) ?? Enumerable.Empty<T>();

        return new DbSet<T>(entities);
    }

    public static void SaveToJson(DbSet<T> set)
    {
        ArgumentNullException.ThrowIfNull(set);

        if (!set.IsDirty)
        {
            return;
        }

        var path = GetFilePath();
        var json = JsonConvert.SerializeObject(set.AsEnumerable(), Formatting.Indented, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        });

        File.WriteAllText(path, json, Encoding.UTF8);
        set.MarkAsClean();
    }

    public static string GetFilePath() => BaseFileName.Replace("{name}", typeof(T).Name.ToLowerInvariant());
}