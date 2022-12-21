using Newtonsoft.Json;

namespace LinqLesson;

internal class Program
{
    private static void Main(string[] args)
    {
        var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json")).ToList();

        var male = persons.Count(p => p.Gender == Gender.Male);
        var female = persons.Count(p => p.Gender == Gender.Female);

        var maxFriends = persons.OrderByDescending(p => p.Friends.Length).First();
        var maxFriends2 = persons.Select(p => p.Friends.Length).Max();
        var maxFriends3 = persons.MaxBy(p => p.Friends.Length);

        //find out who is located farthest north / south / west / east using latitude/ longitude data

        //find max and min distance between 2 persons
        var distances = new List<double>();

        persons.Aggregate(persons, (all, current) =>
        {
            distances.AddRange(all.Select(person =>
                GetDistanceFromLatLonInKm(person.Latitude, person.Longitude, current.Latitude, current.Longitude)));

            return persons;
        });

        var maxDistance = distances.Max(); 
        var minDistance = distances.Min();

        //find 2 persons whos ‘about’ have the most same words

        var about = persons.GroupBy(p => p.About).Where(g => g.Count() > 1).Select(y => y.Key).ToList();

        //find persons with same friends(compare by friend’s name)

        var theSameFriends = persons.GroupBy(p => p.Friends);

        //var userList1 = new List<string>(); 
        //var friends= persons.Where(p=> p.Friends)
        //persons.ForEach();
    }

    public static double GetDistanceFromLatLonInKm(double lat1, double lon1, double lat2, double lon2)
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

    public static double Deg2rad(double deg) => deg * (Math.PI / 180);
} 