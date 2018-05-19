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
                Console.WriteLine(token);
                var mediaType = new MediaTypeWithQualityHeaderValue("aplication/json");

                apiClient.BaseAddress = new Uri("https://localhost:44352/");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);

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
            
            AuthUser user = new AuthUser()
            {
                grant_type = "password",
                username = "tp3@mail.com",
                password = "He1w4mv#"
            };

            using (var apiClient = new HttpClient())
            {

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

                    return "_AUTENTICADO";
                }

            }

            return token;
        }
    }

    class AuthUser
    {
        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
