#if !NETSTANDARD1_6
using System.Web;
using System.Collections.Specialized;

namespace FluentAssertions.Mvc.Fakes
{
    /// <summary>
    /// Mimics a <see cref="HttpRequestBase"/>.  Used for testing
    /// </summary>
    public class FakeHttpRequest : HttpRequestBase
    {
        private string _appRelativePath;
        private string _appPath;

        /// <summary>
        /// Creates a new instance of <see cref="FakeHttpRequest"/>
        /// </summary>
        /// <param name="appPath"></param>
        /// <param name="relativePath"></param>
        public FakeHttpRequest(string appPath, string relativePath)
        {
            _appPath = appPath;
            _appRelativePath = fixRelativeUrl(relativePath);
        }

        private string fixRelativeUrl(string url)
        {
            if (url.StartsWith("/"))
                return "~" + url;

            if (!url.StartsWith("~/"))
                return "~/" + url;

            return url;
        }

        /// <inheritdoc />
        public override string ApplicationPath
        {
            get
            {
                return _appPath;
            }
        }

        /// <inheritdoc />
        public override string AppRelativeCurrentExecutionFilePath
        {
            get
            {
                return _appRelativePath;
            }
        }

        /// <inheritdoc />
        public override string PathInfo
        {
            get
            {
                return string.Empty;
            }
        }

        /// <inheritdoc />
        public override NameValueCollection ServerVariables
        {
            get
            {
                return new NameValueCollection();
            }
        }
    }
}
#endif