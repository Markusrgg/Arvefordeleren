using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Arvefordeleren_ClassLibrary.Models;
using Newtonsoft.Json;

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
        var serialized = await client.GetStringAsync("testator");

        var testators = JsonConvert.DeserializeObject<List<Testator>>(serialized, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        });

        return testators;
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
        var serialized = JsonConvert.SerializeObject(testator, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto, // Include type information in JSON
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore // Ignore circular references
        });
        await client.PutAsJsonAsync("testator", serialized);
    }

    public async Task Delete(Guid id)
    {
        await client.DeleteAsync($"testator/{id}");
    }
}
