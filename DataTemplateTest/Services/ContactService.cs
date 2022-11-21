using DataTemplateTest.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataTemplateTest.Services
{
    public class ContactService
    {
        private readonly HttpClient client;

        public ContactService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://127.0.0.1:5000")
            };
        }

        public async Task<List<Contact>> GetAll()
        {
            var result = await client.GetAsync("contacts/all");
            var content = await result.Content.ReadAsStringAsync();
            var list = JsonSerializer.Deserialize<List<Contact>>(content);
            return list;
        }

        public async Task Add(Contact c)
        {
            var json = JsonSerializer.Serialize(c);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync("contacts", content);
        }

        public async Task Update(Contact c)
        {
            var json = JsonSerializer.Serialize(c);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PutAsync($"contacts/{c.ContactId}", content);
        }

        public async Task Delete(int id)
        {
            await client.DeleteAsync($"contacts/{id}");
        }

    }
}
