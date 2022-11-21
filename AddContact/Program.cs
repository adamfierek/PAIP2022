using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AddContact
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var contact = new Contact();

            Console.Write("FirstName: ");
            contact.FirstName = Console.ReadLine();
            Console.Write("LastName: ");
            contact.LastName = Console.ReadLine();
            Console.Write("PhoneNr: ");
            contact.PhoneNr = Console.ReadLine();

            var client = new HttpClient
            {
                BaseAddress = new Uri("http://127.0.0.1:5000")
            };

            var json = JsonSerializer.Serialize(contact);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await client.PostAsync("contacts", content);

            Console.WriteLine(result);
        }
    }
}
