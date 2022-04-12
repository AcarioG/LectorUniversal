using Microsoft.JSInterop;

namespace LectorUniversal.Client.Helpers
{
    public class ShowMessages : IShowMessages
    {
        private readonly IJSRuntime _js;

        public ShowMessages(IJSRuntime js)
        {
            _js = js;
        }

        public async Task ShowErrorMessage(string message)
        {
            await ShowMessage("Error", message, "error");
        }

        public async Task ShowSuccessMessage(string message)
        {
            await ShowMessage("Success", message, "success");
        }

        private async ValueTask ShowMessage(string title, string message, string typeMessage)
        {
            await _js.InvokeVoidAsync("swal", title, message, typeMessage);
        }
    }
}
