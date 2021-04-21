using AdminDashboard.Infrastructure.Requests.Flights;
using AdminDashboard.Infrastructure.Responses;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Pages.Pages.Users
{
    public partial class Users
    {
        private IEnumerable<UsersResponse> pagedData;
        private MudTable<UsersResponse> table;

        private int totalItems;
        private int currentPage;
        private string searchString = null;
        private async Task<TableData<UsersResponse>> ServerReload(TableState state)
        {
            await LoadData(state.Page, state.PageSize);
            return new TableData<UsersResponse>() { TotalItems = totalItems, Items = pagedData };
        }

        private async Task LoadData(int pageNumber, int pageSize)
        {
            var request = new BaseRequest { PageSize = pageSize, PageNumber = pageNumber + 1 };
            var response = await _usersRepo.GetAllUser(request);
            totalItems = response.TotalCount;
            currentPage = response.CurrentPage;
            var data = response.Data;
            data = data.Where(element =>
            {
                if (string.IsNullOrWhiteSpace(searchString))
                    return true;
                if (element.fullName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    return true;
                if (element.phone.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    return true;
                if (element.email.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    return true;
                return false;
            }).ToList();
            pagedData = data;
        }
        private void OnSearch(string text)
        {
            searchString = text;
            table.ReloadServerData();
        }

        private async Task InvokeModal(string phone)
        {
            var parameters = new DialogParameters();
            if (!string.IsNullOrEmpty(phone))
            {
                var user = pagedData.FirstOrDefault(c => c.phone == phone);
                parameters.Add("phone", user.phone);
                parameters.Add("fullname", user.fullName);
                parameters.Add("email", user.email);
            }
            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddEditUserModal>("Modal", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                OnSearch("");
            }
        }

        private async Task Delete(string id)
        {
            //string deleteContent = localizer["Delete Content"];
            //var parameters = new DialogParameters();
            //parameters.Add("ContentText", string.Format(deleteContent, id));
            //var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            //var dialog = _dialogService.Show<Shared.Dialogs.DeleteConfirmation>("Delete", parameters, options);
            //var result = await dialog.Result;
            //if (!result.Cancelled)
            //{
            //    var response = await _productManager.DeleteAsync(id);
            //    if (response.Succeeded)
            //    {
            //        OnSearch("");
            //        await hubConnection.SendAsync("UpdateDashboardAsync");
            //        _snackBar.Add(localizer[response.Messages[0]], Severity.Success);
            //    }
            //    else
            //    {
            //        OnSearch("");
            //        foreach (var message in response.Messages)
            //        {
            //            _snackBar.Add(localizer[message], Severity.Error);
            //        }
            //    }
            //}
        }
    }
}
