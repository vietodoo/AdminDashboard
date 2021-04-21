namespace AdminDashboard.Infrastructure.Requests.Flights
{
    public class BaseRequest : PagedRequest
    {
        public string SearchString { get; set; }
    }
}
