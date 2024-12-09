using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Arvefordeleren_ClassLibrary.Models;

namespace Arvefordeleren_ClassLibrary.Services;

public class TestatorService
{
    private readonly HttpClient client;

    public TestatorService()
    {
        client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7084/api/Testator");
    }

    public async Task<List<Testator>> GetAll()
    {
        return await client.GetFromJsonAsync<List<Testator>>("testator");
    }

    public async Task<Testator> GetById(Guid id)
    {
        return await client.GetFromJsonAsync<Testator>($"testator/{id}");
    }

    public async Task Create(Testator testator)
    {
        await client.PostAsJsonAsync("testator", testator);
    }

    public async Task Update(Testator testator)
    {
        await client.PutAsJsonAsync("testator", testator);
    }

    public async Task Delete(Guid id)
    {
        await client.DeleteAsync($"testator/{id}");
    }
}
