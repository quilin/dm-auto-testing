namespace DmAutoTesting.WebDrivers
{
    public interface IJavaScriptExecutor
    {
        bool IgnoreAjaxErrors { get; set; }
        void WaitForPendingAjaxRequests();
        void PrepareForAjaxRequests();
        void DisableAnimations();
    }
}