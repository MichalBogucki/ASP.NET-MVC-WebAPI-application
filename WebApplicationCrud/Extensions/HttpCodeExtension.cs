using System.Net;

namespace WebApplicationCrud.Extensions
{
    public static class HttpCodeExtension
    {
        public static int ToInt(this HttpStatusCode httpStatusCode)
        {
            return (int)httpStatusCode;
        }
    }
}