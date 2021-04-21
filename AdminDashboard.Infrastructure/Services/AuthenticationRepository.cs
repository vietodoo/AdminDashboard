using AdminDashboard.Infrastructure.Authentication;
using AdminDashboard.Infrastructure.Contracts;
using AdminDashboard.Infrastructure.Requests.Identity;
using AdminDashboard.Infrastructure.Responses;
using AdminDashboard.Infrastructure.Static;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.Infrastructure.Services
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IHttpClientFactory _client;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationRepository(IHttpClientFactory client,
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _client = client;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> Login(TokenRequest user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.LoginEndpoint);
            var myData = new
            {
                Phone = user.Phone,
                Password = user.Password
            };
            request.Content = new StringContent(JsonConvert.SerializeObject(myData), Encoding.UTF8, "application/json");
            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Wrapper.Result<TokenResponse>>(content);

            //Store Token
            await _localStorage.SetItemAsync("authToken", result.Data.Token);

            //Change auth state of app
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider)
                .LoggedIn();

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", result.Data.Token);

            return true;
        }

        public Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return _authenticationStateProvider.GetAuthenticationStateAsync();
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider)
                .LoggedOut();
        }
    }
}
