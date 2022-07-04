using Microsoft.JSInterop;
using MudBlazor;

namespace LectorUniversal.Client.Helpers
{
    public class ShowMessages : IShowMessages
    {
        //private readonly IJSRuntime _js;
        private readonly ISnackbar _snackbar;

        public ShowMessages(/*IJSRuntime js,*/ ISnackbar snackbar)
        {
            //_js = js;
            _snackbar = snackbar;

        }

        public async Task ShowErrorMessage(string message)
        {
            await ShowMessage(Severity.Error, message);
        }

        public async Task ShowSuccessMessage(string message)
        {
            await ShowMessage(Severity.Success, message);
        }

        private async Task ShowMessage( Severity severityMessage,  string message)
        {
            //await _js.InvokeVoidAsync(title, message, typeMessage);
             Task.Run(() => _snackbar.Add(message, severityMessage)).GetAwaiter().GetResult();
        }
    }
}
