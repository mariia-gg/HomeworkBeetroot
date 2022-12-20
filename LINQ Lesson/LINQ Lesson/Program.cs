using Newtonsoft.Json;

namespace LinqLesson;

internal class Program
{
    private static void Main(string[] args)
    {
        var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));
    }
}