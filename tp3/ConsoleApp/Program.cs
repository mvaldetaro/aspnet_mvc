using Newtonsoft.Json.Linq;
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

        static string token = "";

        static void Main(string[] args)
        {
            TokenAsync();

            using (var apiClient = new HttpClient())
            {
                //Console.WriteLine(token);
                var mediaType = new MediaTypeWithQualityHeaderValue("aplication/json");

                apiClient.BaseAddress = new Uri("https://localhost:44352/");
                apiClient.DefaultRequestHeaders.Accept.Clear();
                apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");

                var message = apiClient.GetAsync("api/Amigoes").Result;

                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine(message.Content.ReadAsStringAsync().Result);
                } else
                {
                    Console.WriteLine("Deu xabu!");
                    Console.WriteLine(message.Content.ReadAsStringAsync().Result);
                }
            }
            Console.ReadKey();
        }

        public static async Task<string> TokenAsync()
        {
            using (var apiClient = new HttpClient())
            {

                // Usuáro criado utilizando a ferramenta Postman
                var stringContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", "tp3@mail.com"),
                        new KeyValuePair<string, string>("password", "He1w4mv#")
                    });

                var TokenUrl = "https://localhost:44352/Token";
                var response = apiClient.PostAsync(TokenUrl, stringContent);

                if(response.Result.IsSuccessStatusCode)
                {
                    var responseContent = await response.Result.Content.ReadAsStringAsync();
                    var tokenData = JObject.Parse(responseContent);

                    token = tokenData["access_token"].ToString();

                    return "_AUTENTICADO_";
                }

            }

            return token;
        }
    }
}
