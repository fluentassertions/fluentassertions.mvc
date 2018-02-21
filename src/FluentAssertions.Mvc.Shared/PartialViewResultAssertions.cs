#if !NETSTANDARD1_6
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Diagnostics;
using FluentAssertions.Primitives;

namespace FluentAssertions.Mvc
{
    /// <summary>
    /// Container for methods that can verify the state or behaviour of a <see cref="PartialViewResult"/>
    /// </summary>
    [DebuggerNonUserCode]
    public class PartialViewResultAssertions : ViewResultBaseAssertions<PartialViewResult>
    {
        /// <summary>
        /// Creates a new instance of <see cref="PartialViewResultAssertions"/>
        /// </summary>
        /// <param name="viewResult"></param>
        public PartialViewResultAssertions(PartialViewResult viewResult) : base(viewResult) { }
    }
}
#endif