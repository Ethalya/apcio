using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Lab06a.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Lab06a.Services
{
    public class StudentsDataStore
    {
        HttpClient _client;
        

        public bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public StudentsDataStore()
        {
            _client = new HttpClient(GetInsecureHandler());
        }

        public async Task<List<Students>> GetItemsAsync(bool v)
        {
            var url = @"https://https://192.168.1.4:45455/api/Students";

            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Students>>(content);
            }

            return new List<Students>();
        }

        public async Task<bool> AddItemAsync(Students item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await _client.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Students item)
        {
            if (item == null || item.Id == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await _client.PutAsync(new Uri($"api/item/{item.Id}"), byteContent);

            return response.IsSuccessStatusCode;

        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await _client.DeleteAsync($"api/item/{id}");

            return response.IsSuccessStatusCode;
        }

        
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain,
            errors) =>
            {
                return true;
            };
            return handler;
        }

    }
}