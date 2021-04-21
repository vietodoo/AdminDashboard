namespace AdminDashboard.Infrastructure.Requests.Flights
{
    public class FlightsRequest : PagedRequest
    {
        public string SearchString { get; set; }
    }
}
