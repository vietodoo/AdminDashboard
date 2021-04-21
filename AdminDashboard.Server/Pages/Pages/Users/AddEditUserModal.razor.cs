using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Pages.Pages.Users
{
    public partial class AddEditUserModal
    {
        private bool success;
        private string[] errors = { };
        private MudForm form;
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
        public string status { get; set; }
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
            }
        }
    }
}
