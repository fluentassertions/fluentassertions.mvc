using System.Web.Mvc;

namespace FluentAssertions.Mvc.Samples.Controllers
{
    public class ProductController : Microsoft.AspNetCore.Mvc.Controller
    {
        public Microsoft.AspNetCore.Mvc.ActionResult List()
        {
            return View("Index");
        }
    }
}
