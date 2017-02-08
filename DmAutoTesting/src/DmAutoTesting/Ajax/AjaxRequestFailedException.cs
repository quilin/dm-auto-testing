using System;

namespace DmAutoTesting.Ajax
{
    public class AjaxRequestFailedException : Exception
    {
        public AjaxRequestFailedException(AjaxRequest failedRequest)
            : base($"Xhr to url {failedRequest.Url} has failed with code {failedRequest.HttpStatusCode}.")
        {
        }
    }
}