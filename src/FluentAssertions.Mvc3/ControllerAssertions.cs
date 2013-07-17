using System;
using System.Diagnostics;
using System.Web.Mvc;
using FluentAssertions.Primitives;

namespace FluentAssertions.Mvc
{
    [DebuggerNonUserCode]
	public class ControllerAssertions : ObjectAssertions
	{
        public ControllerAssertions(Controller subject) : base(subject)
        {
            Subject = subject;
        } 

        public ControllerAssertions HaveAuthorizeAttribute()
        {
            var type = Subject.GetType();

            type.Should().BeDecoratedWith<AuthorizeAttribute>();

            return this;       
        }
	}
}

