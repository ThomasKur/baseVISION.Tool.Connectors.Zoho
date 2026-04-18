using System;

namespace baseVISION.Tool.Connectors.Zoho
{
    public class ZohoRateLimitException : Exception
    {
        public ZohoRateLimitException(string message, Exception innerException = null)
            : base(message, innerException) { }
    }
}
