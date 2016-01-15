using Microsoft.AspNet.Mvc;

namespace FluentAssertions.Mvc6.Sample.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = "foo";
            return View(model);
        }
    }
}
