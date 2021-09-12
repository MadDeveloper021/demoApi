using HackRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HackRegistration.HttpRepository
{
    public class HacksHttpRepository : IHacksHttpRepository
    {
       
        private readonly HttpClient _client;

        JsonSerializerOptions _options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        public HacksHttpRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<Hacks>> GetHacks()
        {
            //_client. = new Uri("https://localhost:44306");
            var hackRegistrations = await _client.GetAsync("https://localhost:44306/api/HackRegistrations");
            var responseStream = await hackRegistrations.Content.ReadAsStringAsync();
            List<Hacks> hacks = JsonSerializer.Deserialize<List<Hacks>>(responseStream, _options);
            return hacks;
        }

        public async Task<Hacks> GetHacksById(int id)
        {
            //_client. = new Uri("https://localhost:44306");
            var hackRegistrations = await _client.GetAsync("https://localhost:44306/api/HackRegistrations/"+id);
            var responseStream = await hackRegistrations.Content.ReadAsStringAsync();
            Hacks hacks = JsonSerializer.Deserialize<Hacks>(responseStream, _options);
            return hacks;
        }

        public async Task<string>  DeleteHacks(string HackIds)
        {
            var response = await _client.DeleteAsync("https://localhost:44306/api/HackRegistrations/" + HackIds);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return "Success";
            }
            else
            {
                return "Failure";
            }
        }

        public async Task<string> InsertHacks(Hacks hacks)
        {
            hacks.Dob = Convert.ToDateTime(hacks.Dob);
            string serializedObject = JsonSerializer.Serialize(hacks);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(serializedObject, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("https://localhost:44306/api/HackRegistrations", httpContent);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return "Success";
            }
            else
            {
                return "Failure";
            }
        }

       public async Task<string> UpdateHacks(int id, Hacks hacks)
        {
            string serializedObject = JsonSerializer.Serialize(hacks);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(serializedObject, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("https://localhost:44306/api/HackRegistrations/" + id, httpContent);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return "Success";
            }
            else
            {
                return "Failure";
            }
        }

        //public string 
    }
}
