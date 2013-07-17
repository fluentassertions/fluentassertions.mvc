using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FluentAssertions.Mvc.Tests.Fakes
{
    [Authorize(Roles="Admin")]
    public class FakeAdminController : Controller
    {
        public ActionResult IndexReturn { get; set; }

        public ActionResult Index()
        {
            return IndexReturn;
        }
    }
}
