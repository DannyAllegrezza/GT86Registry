using Microsoft.AspNetCore.Mvc;

namespace GT86Registry.Web.Helpers
{
    public class PageNotFound : ViewResult
    {
        public PageNotFound()
        {
            ViewName = "PageNotFound";
            StatusCode = 404;
        }
    }
}