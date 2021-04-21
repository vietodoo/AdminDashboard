using AdminDashboard.Infrastructure.Requests.Users;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Pages.Pages.Users
{
    public partial class AddEditUserModal
    {
        private bool success;
        private string[] errors = { };
        private MudForm form;
        [Parameter]
        public string id { get; set; }
        [Parameter]
        [Required]
        public string fullName { get; set; }
        [Parameter]
        [Required]
        public string phone { get; set; }
        [Parameter]
        [Required]
        public string email { get; set; }
        [Parameter]
        [Required]
        public string password { get; set; }
        [Parameter]
        public bool isStatus { get; set; } = false;
        [Parameter]
        public string level { get; set; }
        [Parameter]
        public string gender { get; set; }

        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        public void Cancel()
        {
            MudDialog.Cancel();
        }

        private async Task SaveAsync()
        {
            form.Validate();
            if (form.IsValid)
            {
                var userRegisterRequest = new UserRegisterRequest() 
                {
                    fullName = fullName,
                    phone = phone,
                    email = email,
                    password = password,
                    status = isStatus ? "ACTIVE": "PENDING",
                    gender = gender,
                    level = "MEMBER"
                };
                var result = await _usersRepo.UserRegister(userRegisterRequest);
                if (result)
                {
                    _snackBar.Add("Thêm user thàng công", Severity.Success);
                    MudDialog.Close();
                }
                else
                {
                    _snackBar.Add("Thêm user thất bại", Severity.Error);
                }
            }
        }
    }
}
