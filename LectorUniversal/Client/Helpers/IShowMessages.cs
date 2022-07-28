namespace LectorUniversal.Client.Helpers
{
    public interface IShowMessages
    {
        Task ShowErrorMessage(string message);
        Task ShowSuccessMessage(string message);
        Task ShowWarningMessage(string message);
        Task ShowInfoMessage(string message);
    }
}
