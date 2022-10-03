using FirstWebApi.ApiClients.Contracts;

namespace FirstWebApi.ApiClients
{
    public interface IJsonPlaceholderApiClient
    {
        Task<List<PlaceholderUser>> FetchData();
    }
}