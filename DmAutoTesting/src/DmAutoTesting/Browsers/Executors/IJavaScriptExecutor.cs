namespace DmAutoTesting.Browsers.Executors
{
    public interface IJavaScriptExecutor
    {
        bool IgnoreAjaxErrors { get; set; }
        void WaitForPendingAjaxRequests();
        void PrepareForAjaxRequests();
    }
}