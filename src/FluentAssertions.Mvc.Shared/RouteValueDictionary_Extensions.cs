using System.Web.Mvc;
using System.Web.Routing;
using FluentAssertions.Mvc.Fakes;

namespace FluentAssertions.Mvc
{
    /// <summary>
    /// Contains extension methods for <see cref="RouteValueDictionary"/>
    /// </summary>
    public static class RouteValueDictionary_Extensions
    {
        /// <summary>
        /// Wraps a call to <see cref="UrlHelper.GenerateUrl(string, string, string, RouteValueDictionary, RouteCollection, RequestContext, bool)"/> using a stub <see cref="System.Web.HttpContextBase"/>
        /// </summary>
        /// <param name="routeValues">The <see cref="RouteValueDictionary"/> to generate the URL from</param>
        /// <param name="routes">a <see cref="RouteCollection"/> for use when generating a URL</param>
        /// <returns>A URL value generated from the given <paramref name="routeValues"/> and <paramref name="routes"/></returns>
        public static string GenerateUrl(this RouteValueDictionary routeValues, RouteCollection routes)
        {
            var context = new FakeHttpContext("/", "~/");
            var requestContext = new RequestContext(context, new RouteData());
            var url = UrlHelper.GenerateUrl(null, null, null, routeValues, routes, requestContext, true);
            return url;
        }
    }
}
