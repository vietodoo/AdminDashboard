namespace AdminDashboard.Infrastructure.Static
{
    public static class Endpoints
    {
        public static string BaseUrl = "http://14.225.17.156:8071/";
        public static string RegisterEndpoint = $"{BaseUrl}api/users/register/";
        public static string LoginEndpoint = $"{BaseUrl}user/authenticate";
    }
}
