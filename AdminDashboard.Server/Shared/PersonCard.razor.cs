using AdminDashboard.Infrastructure.Extensions;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Shared
{
    public partial class PersonCard
    {
        [Parameter]
        public string Class { get; set; }
        [Parameter]
        public string Style { get; set; }
        [Parameter]
        public string ImageDataUrl { get; set; }
        private string FullName { get; set; }
        private string Email { get; set; }
        private char FirstLetterOfName { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }
        private async Task LoadDataAsync()
        {            
            var state = await _authRepo.GetAuthenticationStateAsync();
            if (!state.User.Claims.Any())
            {
                _navigationManager.NavigateTo("/");
                return;
            }
            var user = state.User;
            this.Email = user.GetEmail().Split("@")[0];
            this.FullName = user.GetFullName();
            if (this.FullName.Length > 0)
            {
                FirstLetterOfName = this.FullName[0];
            }
            var UserId = user.GetUserId();
        }
    }
}
