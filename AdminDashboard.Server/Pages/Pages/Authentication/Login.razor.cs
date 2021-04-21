using AdminDashboard.Infrastructure.Requests.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using System.Linq;
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
            if (state.User.Claims.Any())
            {
                _navigationManager.NavigateTo("/dashboard");
                return;
            }
        }

        private async Task SubmitAsync()
        {
            var response = await _authRepo.Login(model);
            if (response) _navigationManager.NavigateTo("/dashboard");
        }
    }
}
