using AdminDashboard.Infrastructure.Requests.Flights;
using AdminDashboard.Infrastructure.Responses;
using AdminDashboard.Infrastructure.Wrapper;
using System.Threading.Tasks;

namespace AdminDashboard.Infrastructure.Contracts
{
    public interface IFlightsRepository
    {
        Task<PaginatedResult<FlightsResponse>> GetTicketFormPdf(FlightsRequest flightsRequest);
    }
}
