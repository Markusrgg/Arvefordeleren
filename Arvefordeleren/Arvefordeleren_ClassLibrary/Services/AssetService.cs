using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Arvefordeleren_ClassLibrary.Models;
namespace Arvefordeleren_ClassLibrary.Services
{
    public class AssetService
    {
        Uri baseAdress = new Uri("https://localhost:7084/api/asset");
        private readonly HttpClient _httpClient;

        public AssetService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAdress;
        }

        public async Task<List<Asset>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Asset>>("asset");
        }

        public async Task<Asset> GetById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Asset>($"asset/{id}");
        }

        public async Task Create(Asset asset)
        {
            await _httpClient.PostAsJsonAsync("asset", asset);
        }

        public async Task Update(Asset asset)
        {
            await _httpClient.PutAsJsonAsync($"asset/{asset.Id}", asset);
        }

        public async Task Delete(Guid id)
        {
            await _httpClient.DeleteAsync($"asset/{id}");
        }
    }
}