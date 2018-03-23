using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                var jokeJson = client.DownloadString(@"https://api.chucknorris.io/jokes/random");
                var jokeDef = new { value = "" };
                var jokeString = JsonConvert.DeserializeAnonymousType(jokeJson, jokeDef);
                Console.WriteLine(jokeString.value);
            }
        }
    }
}
