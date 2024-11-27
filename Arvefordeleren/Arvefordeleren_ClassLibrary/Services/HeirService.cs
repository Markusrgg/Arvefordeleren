using System;
using System.Net.Http;
using System.Net.Http.Json;
using Arvefordeleren_ClassLibrary.Models;

namespace Arvefordeleren_ClassLibrary.Services;

public class HeirService
{
    private readonly HttpClient client;

    public HeirService()
    {
        client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7084/api/Heir");
    }

    public async Task<List<Heir>> GetAll()
    {
        return await client.GetFromJsonAsync<List<Heir>>("heir");
    }

    public async Task<Heir> GetById(Guid id)
    {
        return await client.GetFromJsonAsync<Heir>($"heir/{id}");
    }

    public async Task Create(Heir heir)
    {
        await client.PostAsJsonAsync("heir", heir);
    }

    public async Task Update(Heir heir)
    {
        await client.PutAsJsonAsync("heir", heir);
    }

    public async Task Delete(Guid id)
    {
        await client.DeleteAsync($"heir/{id}");
    }
}
