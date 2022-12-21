using Newtonsoft.Json;

namespace LinqLesson;

internal class Program
{
    private static void Main(string[] args)
    {
        var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"))?.ToList();

        if (persons == null)
        {
            Console.WriteLine("No data found");

            return;
        }

        var maleCount = persons.Count(p => p.Gender == Gender.Male);
        var femaleCount = persons.Count(p => p.Gender == Gender.Female);

        var maxFriendsCount = persons.OrderByDescending(p => p.Friends.Length).First();
        var maxFriendsCount2 = persons.Select(p => p.Friends.Length).Max();
        var maxFriendsCount3 = persons.MaxBy(p => p.Friends.Length);

        //find out who is located farthest north / south / west / east using latitude / longitude data

        var personLocatedFarthestNorth = persons.MaxBy(p => p.Latitude);
        var personLocatedFarthestSouth = persons.MinBy(p => p.Latitude);
        var personLocatedFarthestWest = persons.MinBy(p => p.Longitude);
        var personLocatedFarthestEast = persons.MaxBy(p => p.Longitude);

        //find max and min distance between 2 persons

        var distances = new List<double>();

        persons.ForEach(personX =>
            distances.AddRange(persons.Select(personY =>
                GetDistanceFromLatLonInKm(personY.Latitude, personY.Longitude, personX.Latitude, personX.Longitude))));

        var maxDistance = distances.Max();
        var minDistance = distances.Min();

        //find 2 persons whos ‘about’ have the most same words
        var personsWithMaxCommonWordsCount = persons
            .SelectMany(personX => persons
                .Select(personY => new
                {
                    Person1 = personX,
                    Person2 = personY,
                    CommonWordsCount = personX
                        .About
                        .Split(
                            new[] { ' ', ',', '.', '!', '?', ':', ';', '(', ')', '"' },
                            StringSplitOptions.RemoveEmptyEntries
                        )
                        .Intersect(personY.About.Split(
                            new[] { ' ', ',', '.', '!', '?', ':', ';', '(', ')', '"' },
                            StringSplitOptions.RemoveEmptyEntries
                        ))
                        .Count()
                }))
            .Where(x => x.Person1 != x.Person2)
            .MaxBy(x => x.CommonWordsCount);

        //find persons with same friends(compare by friend’s name)

        var personsWithSameFriends = persons
            .SelectMany(person => persons
                .Where(p => p.Friends.IntersectBy(person.Friends.Select(x => x.Name), friend => friend.Name).Any())
                .Select(p => new
                {
                    Person = person,
                    Friend = p
                }));
    }

    private static double GetDistanceFromLatLonInKm(double lat1, double lon1, double lat2, double lon2)
    {
        var R = 6371; // Radius of the earth in km
        var dLat = Deg2rad(lat2 - lat1); // deg2rad below
        var dLon = Deg2rad(lon2 - lon1);

        var a =
            Math.Sin(dLat / 2) * Math.Sin(dLat / 2)
            + Math.Cos(Deg2rad(lat1)) * Math.Cos(Deg2rad(lat2)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        var d = R * c; // Distance in km

        return d;
    }

    private static double Deg2rad(double deg) => deg * (Math.PI / 180);
}