using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions.Mvc;
using FluentAssertions.Mvc.Tests.Fakes;
using NUnit.Framework;

namespace FluentAssertions.Mvc.Tests
{
    [TestFixture]
    public class ControllerAssertions_Tests
    {
        [Test]
        public void HaveAuthorizeAttribute_GivenExpected_ShouldPass()
        {
            var controller = new FakeAdminController();
            controller.Should().HaveAuthorizeAttribute();
        }

        [Test]
        public void HaveAuthorizeAttribute_GivenUnexpected_ShouldFail()
        {
            var controller = new FakeController();
            
            Action act = () => controller.Should().HaveAuthorizeAttribute();

            act.ShouldThrow<Exception>();
        }
    }
}
