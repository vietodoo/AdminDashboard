using AdminDashboard.Infrastructure.Requests.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Pages.Pages.Authentication
{
    public partial class Login
    {
        private TokenRequest model = new TokenRequest();

        protected override async Task OnInitializedAsync()
        {
            var state = await _authRepo.GetAuthenticationStateAsync();
            if (state != new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())))
            {
                _navigationManager.NavigateTo("/dashboard");
            }
        }

        private async Task SubmitAsync()
        {
            var response = await _authRepo.Login(model);
            if (response) _navigationManager.NavigateTo("/dashboard");
        }
    }
}
