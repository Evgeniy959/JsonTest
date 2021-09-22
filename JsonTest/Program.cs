using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonTest
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static async Task Main()
        {
            var user = new User
            {
                Name = "Andrey",
                Age = 33
            };

            using (var file_output = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(file_output, user);
            }

            var person = new User();
            using (var file_input = new FileStream("user.json", FileMode.Open))
            {
                person = JsonSerializer.DeserializeAsync<User>(file_input).Result;
            }
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}

