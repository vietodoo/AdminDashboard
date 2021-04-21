using AdminDashboard.Infrastructure.Requests.Flights;
using AdminDashboard.Infrastructure.Responses;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Pages.Pages.Flights
{
    public partial class Flights
    {
        private IEnumerable<FlightsResponse> pagedData;
        private MudTable<FlightsResponse> table;

        private int totalItems;
        private int currentPage;
        private string searchString = null;
        private async Task<TableData<FlightsResponse>> ServerReload(TableState state)
        {
            await LoadData(state.Page, state.PageSize);
            return new TableData<FlightsResponse>() { TotalItems = totalItems, Items = pagedData };
        }

        private async Task LoadData(int pageNumber, int pageSize)
        {
            var request = new FlightsRequest { PageSize = pageSize, PageNumber = pageNumber + 1 };
            var response = await _flightsRepo.GetTicketFormPdf(request);
            if (response.Succeeded)
            {
                totalItems = response.TotalCount;
                currentPage = response.CurrentPage;
                var data = response.Data;
                data = data.Where(element =>
                {
                    if (string.IsNullOrWhiteSpace(searchString))
                        return true;
                    if (element.appCode.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                        return true;
                    if (element.empName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                        return true;
                    if (element.orderId.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                        return true;
                    return false;
                }).ToList();
                pagedData = data;
            }
            else
            {
                //foreach (var message in response.Messages)
                //{
                //    _snackBar.Add(localizer[message], Severity.Error);
                //}
            }
        }
        private void OnSearch(string text)
        {
            searchString = text;
            table.ReloadServerData();
        }

        private async Task InvokeModal(string id)
        {
            //var parameters = new DialogParameters();
            //if (id != 0)
            //{
            //    var product = pagedData.FirstOrDefault(c => c.Id == id);
            //    parameters.Add("Id", product.Id);
            //    parameters.Add("Name", product.Name);
            //    parameters.Add("Description", product.Description);
            //    parameters.Add("Rate", product.Rate);
            //    parameters.Add("Brand", product.Brand);
            //    parameters.Add("BrandId", product.BrandId);
            //    parameters.Add("Barcode", product.Barcode);
            //}
            //var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
            //var dialog = _dialogService.Show<AddEditProductModal>("Modal", parameters, options);
            //var result = await dialog.Result;
            //if (!result.Cancelled)
            //{
            //    OnSearch("");
            //}
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
