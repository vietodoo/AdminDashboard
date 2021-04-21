using AdminDashboard.Infrastructure.Contracts;
using AdminDashboard.Infrastructure.Requests.Flights;
using AdminDashboard.Infrastructure.Responses;
using AdminDashboard.Infrastructure.Static;
using AdminDashboard.Infrastructure.Wrapper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AdminDashboard.Infrastructure.Services
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IHttpClientFactory _client;
        private readonly ILocalStorageService _localStorage;

        public UsersRepository(IHttpClientFactory client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public async Task<PaginatedResult<UsersResponse>> GetAllUser(BaseRequest baseRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoints.UserGetAllUserEndpoint);
            var client = _client.CreateClient();
            var savedToken = await this._localStorage.GetItemAsync<string>("authToken");

            if (!string.IsNullOrWhiteSpace(savedToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", savedToken);
            }
            HttpResponseMessage response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginatedResult<UsersResponse>>(content);
            return result;
        }
    }
}
