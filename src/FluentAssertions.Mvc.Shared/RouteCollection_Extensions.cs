using System.Web.Routing;
using FluentAssertions.Mvc.Fakes;
using System.Diagnostics;

namespace FluentAssertions.Mvc
{
    /// <summary>
    /// Container for extension methods for <see cref="RouteCollection"/>
    /// </summary>
    [DebuggerNonUserCode]
    public static class RouteCollection_Extensions
    {
        /// <summary>
        /// Spoofs a call to <see cref="RouteCollection.GetRouteData(System.Web.HttpContextBase)"/> with the use of a stub <see cref="System.Web.HttpContextBase"/>.
        /// </summary>
        /// <param name="routes">The <see cref="RouteCollection"/> to spoof the call on.</param>
        /// <param name="url">The url of interest</param>
        /// <returns>A <see cref="RouteCollection"/> for the given <paramref name="url"/></returns>
        public static RouteData GetRouteDataForUrl(this RouteCollection routes, string url)
        {
            var context = new FakeHttpContext("/", url);
            var routeData = routes.GetRouteData(context);
            return routeData;
        }
    }
}
