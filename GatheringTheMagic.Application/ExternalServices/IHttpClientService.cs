using GatheringTheMagic.Application.ExternalServices.DTOS.Response;

namespace GatheringTheMagic.Application.ExternalServices;

public interface IHttpClientService
{
    Task<TResponse?> GetAsync<TResponse>(string uri);
    Task<TResponse?> PostAsync<TRequest, TResponse>(string uri, TRequest body);
    Task<TResponse?> PutAsync<TRequest, TResponse>(string uri, TRequest body);
    Task DeleteAsync(string uri);
}
