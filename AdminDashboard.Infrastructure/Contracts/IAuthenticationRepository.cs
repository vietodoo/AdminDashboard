using AdminDashboard.Infrastructure.Requests.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace AdminDashboard.Infrastructure.Contracts
{
    public interface IAuthenticationRepository
    {
        public Task<bool> Login(TokenRequest user);
        public Task Logout();
        public Task<AuthenticationState> GetAuthenticationStateAsync();
    }
}
