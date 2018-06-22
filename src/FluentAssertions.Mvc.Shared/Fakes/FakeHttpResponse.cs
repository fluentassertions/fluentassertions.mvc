using System.Web;

namespace FluentAssertions.Mvc.Fakes
{
    /// <summary>
    /// Mimics a <see cref="HttpResponseBase"/>.  For use in testing.
    /// </summary>
    public class FakeHttpResponse : HttpResponseBase
    {
        /// <inheritdoc />
        public override string ApplyAppPathModifier(string virtualPath)
        {
            return virtualPath;
        }
    }
}
