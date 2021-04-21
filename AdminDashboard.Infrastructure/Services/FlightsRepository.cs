using AdminDashboard.Infrastructure.Contracts;
using AdminDashboard.Infrastructure.Requests.Flights;
using AdminDashboard.Infrastructure.Responses;
using AdminDashboard.Infrastructure.Static;
using AdminDashboard.Infrastructure.Wrapper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdminDashboard.Infrastructure.Services
{
    public class FlightsRepository : IFlightsRepository
    {
        private readonly IHttpClientFactory _client;
        private readonly ILocalStorageService _localStorage;

        public FlightsRepository(IHttpClientFactory client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public async Task<PaginatedResult<FlightsResponse>> GetTicketFormPdf(FlightsRequest flightsRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoints.FlightGetTicketFormPdfEndpoint);
            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginatedResult<FlightsResponse>>(content);
            return result;
        }
    }
}
