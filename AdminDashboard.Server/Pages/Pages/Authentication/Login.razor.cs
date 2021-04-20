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
           
        }

        private async Task SubmitAsync()
        {
            var response = await _authRepo.Login(model);
            if (response) _navigationManager.NavigateTo("/");
        }
    }
}
