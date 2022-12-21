using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using LinqLesson;

namespace LinqLesson;

internal class Program 
{
    private static void Main(string[] args)
    {
        var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json")).ToList();

        var male = persons.Count(p => p.Gender == Gender.Male);
        var female = persons.Count(p => p.Gender == Gender.Female);

        var maxFriends = persons.OrderByDescending(p => p.Friends.Length).First();

        //find out who is located farthest north / south / west / east using latitude/ longitude data
      


        //find max and min distance between 2 persons
        var orderedList = persons.GroupBy(x=> x.Latitude).Max();
        //find 2 persons whos ‘about’ have the most same words

        var about  = persons.GroupBy(p=>p.About).Where(g => g.Count() > 1).Select(y => y.Key).ToList();

        //find persons with same friends(compare by friend’s name)

        var theSameFriends = persons.GroupBy(p => p.Friends); 





        //var userList1 = new List<string>(); 
        //var friends= persons.Where(p=> p.Friends)
        //persons.ForEach();

    }
}