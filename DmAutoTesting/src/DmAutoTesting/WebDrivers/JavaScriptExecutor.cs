using System.IO;
using System.Linq;
using DmAutoTesting.Ajax;
using DmAutoTesting.Browsers;
using DmAutoTesting.Core;
using log4net;
using Newtonsoft.Json;

namespace DmAutoTesting.WebDrivers
{
    public class JavaScriptExecutor : IJavaScriptExecutor
    {
        private readonly IBrowserAdapter browserAdapter;
        private readonly ILog log = LogManager.GetLogger(typeof(TestResultsStorage));
        private readonly JsonSerializer jsonSerializer;

        public JavaScriptExecutor(
            IBrowserAdapter browserAdapter
            )
        {
            this.browserAdapter = browserAdapter;
            jsonSerializer = JsonSerializer.CreateDefault();
        }

        public bool IgnoreAjaxErrors { get; set; }
        public void WaitForPendingAjaxRequests()
        {
            WaitForAjaxRequests();
            var requests = ReadRequestsState();

            if (requests == string.Empty)
            {
                return;
            }

            var stringReader = new StringReader(requests);
            var jsonTextReader = new JsonTextReader(stringReader);
            var ajaxRequests = jsonSerializer.Deserialize<AjaxRequest[]>(jsonTextReader);

            if (ajaxRequests.Length == 0)
            {
                return;
            }

            var failedCount = ajaxRequests.Count(x => x.State == AjaxRequestState.Failed);
            if (failedCount == 0)
            {
                log.InfoFormat("Xhrs complete: {0}\n{1}", ajaxRequests.Length, requests);
            }
            else
            {
                log.InfoFormat("Xhrs complete: {0}, failed among them: {1}\n{2}", ajaxRequests.Length, failedCount, requests);
                if (!IgnoreAjaxErrors)
                {
                    throw new AjaxRequestFailedException(ajaxRequests.First(x => x.State == AjaxRequestState.Failed));
                }
            }
        }

        private string ReadRequestsState()
        {
            const string script = "if (typeof jQuery == 'undefined') return ''; \n" +
                                  "return (typeof ajaxRequests == 'undefined') ? '' : JSON.stringify(ajaxRequests)";
            var response = browserAdapter.ExecuteScript(script);
            return response;
        }

        public void PrepareForAjaxRequests()
        {
            WaitForAjaxRequests();

            const string script = "if (typeof jQuery == 'undefined') return; \n" +
                                  "if (typeof ajaxRequests != 'undefined') { \n" +
                                  "    ajaxRequests = []; \n" +
                                  "    return; \n" +
                                  "} \n" +
                                  "ajaxRequests = []; \n" +
                                  "$(document).ajaxSend(function(event, jqxhr, settings) { \n" +
                                  "    var ajaxRequest = { \n" +
                                  "                          async: settings.async, \n" +
                                  "                          type: settings.type, \n" +
                                  "                          url: settings.url, \n" +
                                  "                          state: 'Pending', \n" +
                                  "                          postData: settings.type == 'POST' ? settings.data : '' \n" +
                                  "                      }; \n" +
                                  "    ajaxRequests.push(ajaxRequest); \n" +
                                  "}); \n" +
                                  "$(document).ajaxSuccess(function(event, jqxhr, settings) { \n" +
                                  "    for (var i in ajaxRequests) { \n" +
                                  "        if (ajaxRequests[i].url == settings.url) { \n" +
                                  "            ajaxRequests[i].state = 'Succeeded'; \n" +
                                  "            ajaxRequests[i].httpStatusCode = jqxhr.status; \n" +
                                  "        } \n" +
                                  "    } \n" +
                                  "}); \n" +
                                  "$(document).ajaxError(function(event, jqxhr, settings) { \n" +
                                  "    for (var i in ajaxRequests) { \n" +
                                  "        if (ajaxRequests[i].url == settings.url) { \n" +
                                  "            ajaxRequests[i].state = 'Failed'; \n" +
                                  "            ajaxRequests[i].httpStatusCode = jqxhr.status; \n" +
                                  "        } \n" +
                                  "    } \n" +
                                  "});";
            browserAdapter.ExecuteScript(script);
        }

        public void DisableAnimations()
        {
            const string script = "if (typeof jQuery == 'undefined') return; \n" +
                                  "jQuery.fx.off = true; \n";
            browserAdapter.ExecuteScript(script);
        }

        private void WaitForAjaxRequests()
        {
            const string script = "return (typeof jQuery == 'undefined' || jQuery.active == 0).toString()";
            Wait.For(() => bool.Parse(browserAdapter.ExecuteScript(script)), () => $"Could not wait for Xhrs to complete. The state is {ReadRequestsState()}", 80000);
        }
    }
}