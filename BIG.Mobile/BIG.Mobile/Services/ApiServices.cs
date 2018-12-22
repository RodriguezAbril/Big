using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using BIG.Mobile.Models;
using System.Threading.Tasks;
using System.Diagnostics;


namespace BIG.Mobile.Services
{
    public class ApiServices
    {
        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            // throw new NotImplementedException();
            var client = new HttpClient();
            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            //var response = await client.PostAsync("http://localhost:52049/api/Account/Register", content);

            var response = await client.PostAsync("http://webidentity2018.azurewebsites.net/api/Account/Register", content);
            return response.IsSuccessStatusCode;



        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var KeyValues = new List<KeyValuePair<string, string>>
            {

                new KeyValuePair<string, string>("username",username),
                new KeyValuePair<string, string>("password",password),
                new KeyValuePair<string, string>("grant_type","password"),

            };

            //var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:52049/Token");
            var request = new HttpRequestMessage(HttpMethod.Post, "http://webidentity2018.azurewebsites.net/Token");
            request.Content = new FormUrlEncodedContent(KeyValues);
            
            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            Debug.WriteLine(content);

            return response.IsSuccessStatusCode;

        }

    }
}
