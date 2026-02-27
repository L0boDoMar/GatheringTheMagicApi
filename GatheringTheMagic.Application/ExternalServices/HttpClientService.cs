using GatheringTheMagic.Application.ExternalServices.DTOS.Response;
using System.Net.Http.Json;
using System.Text.Json;

namespace GatheringTheMagic.Application.ExternalServices;

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;

    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<TResponse?> GetAsync<TResponse>(string uri)
    {
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TResponse>(_options);
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string uri, TRequest body)
    {
        var response = await _httpClient.PostAsJsonAsync(uri, body);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TResponse>(_options);
    }

    public async Task<TResponse?> PutAsync<TRequest, TResponse>(string uri, TRequest body)
    {
        var response = await _httpClient.PutAsJsonAsync(uri, body);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TResponse>(_options);
    }

    public async Task DeleteAsync(string uri)
    {
        var response = await _httpClient.DeleteAsync(uri);
        response.EnsureSuccessStatusCode();
    }

}