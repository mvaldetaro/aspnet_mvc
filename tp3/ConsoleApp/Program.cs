using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var apiClient = new HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("aplication/json");

                apiClient.BaseAddress = new Uri("https://localhost:44352/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);

                var message = apiClient.GetAsync("api/Amigoes").Result;

                if (message.IsSuccessStatusCode)
                {
                    Console.Write(message.Content.ReadAsStringAsync().Result);
                } else
                {
                    Console.Write("Deu xabu!");
                    Console.Write(message.Content.ReadAsStringAsync().Result);
                }
            }
            Console.ReadKey();
        }
    }
}
