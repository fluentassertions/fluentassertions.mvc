using System;
#if NETCOREAPP1_0
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
#else
using System.Web.Mvc;
using System.Web.Routing;
#endif
using NUnit.Framework;

namespace FluentAssertions.Mvc.Tests
{
    [TestFixture]
    public class RedirectToRoute_Tests
    {
        [Test]
		public void WithPermanent_GivenExpected_ShouldPass()
		{
            ActionResult result = new RedirectToRouteResult("", null, true);
            result.Should()
                    .BeRedirectToRouteResult()
                    .WithPermanent(true);
		}

        [Test]
        public void WithPermanent_GivenUnExpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("", null, true);
            Action a = () => result.Should()
                    .BeRedirectToRouteResult()
                    .WithPermanent(false);
            a.Should().Throw<Exception>()
                    .WithMessage("Expected RedirectToRoute.Permanent to be False, but found True");
        }

        [Test]
        public void WithRouteName_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("default", null);
            result.Should()
                    .BeRedirectToRouteResult()
                    .WithRouteName("default");
        }

        [Test]
        public void WithRouteName_GivenUnExpected_ShouldFail()
        {
            ActionResult result = new RedirectToRouteResult("default", null);
            Action a = () => result.Should()
                    .BeRedirectToRouteResult()
                    .WithRouteName("xyz");
            a.Should().Throw<Exception>()
                .WithMessage("Expected RedirectToRoute.RouteName to be \"xyz\", but found \"default\"");
        }

        [Test]
        public void WithRouteValue_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Id = "22"
                }));

            result.Should()
                    .BeRedirectToRouteResult()
                    .WithRouteValue("Id", "22");
        }

        [Test]
        public void WithRouteValue_GivenUnexpected_ShouldFail()
        {
            var subjectIdentifier = GetSubjectIdentifier();

            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Id = "22"
                }));

            Action a = () => result.Should()
                    .BeRedirectToRouteResult()
                    .WithRouteValue("Id", "11");
            a.Should().Throw<Exception>()
                    .WithMessage($"Expected {subjectIdentifier} to contain value \"11\" at key \"Id\", but found \"22\".");            
        }

        [Test]
        public void WithController_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Controller = "home"
                }));

            result.Should()
                    .BeRedirectToRouteResult()
                    .WithController("home");
        }

        [Test]
        public void WithController_GivenUnexpected_ShouldFail()
        {
            var subjectIdentifier = GetSubjectIdentifier();

            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Controller = "home"
                }));

            Action a = () => result.Should()
                    .BeRedirectToRouteResult()
                    .WithController("xyz");
            a.Should().Throw<Exception>()
                    .WithMessage($"Expected {subjectIdentifier} to contain value \"xyz\" at key \"Controller\", but found \"home\".");
        }

        [Test]
        public void WithAction_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Action = "index"
                }));

            result.Should()
                    .BeRedirectToRouteResult()
                    .WithAction("index");
        }

        [Test]
        public void WithAction_GivenUnexpected_ShouldFail()
        {
            var subjectIdentifier = GetSubjectIdentifier();

            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Action = "index"
                }));

            Action a = () => result.Should()
                    .BeRedirectToRouteResult()
                    .WithAction("xyz");
            a.Should().Throw<Exception>()
                    .WithMessage($"Expected {subjectIdentifier} to contain value \"xyz\" at key \"Action\", but found \"index\".");
        }

        [Test]
        public void WithArea_GivenExpected_ShouldPass()
        {
            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Area = "accounts"
                }));

            result.Should()
                    .BeRedirectToRouteResult()
                    .WithArea("accounts");
        }

        [Test]
        public void WithArea_GivenUnexpected_ShouldFail()
        {
            var subjectIdentifier = GetSubjectIdentifier();

            ActionResult result = new RedirectToRouteResult("", new RouteValueDictionary(
                new
                {
                    Area = "accounts"
                }));

            Action a = () => result.Should()
                    .BeRedirectToRouteResult()
                    .WithArea("xyz");
            a.Should().Throw<Exception>()
                    .WithMessage($"Expected {subjectIdentifier} to contain value \"xyz\" at key \"Area\", but found \"accounts\".");
        }

        /// <summary>
        /// Gets the expected subject identifier for the failure message
        /// </summary>
        /// <remarks>
        /// The Fluent Assertions library will attempt to determine the name of the subject from the stack trace.
        /// This requires the Unit Tests to be compiled in DEBUG mode in order for it to work successfully.
        /// If it cannot determne the Subject's Identity, it will fall back to a generic value.
        /// This method is an attempt to cope with the different build configurations
        /// ref: http://fluentassertions.com/documentation.html#subject-identification
        /// </remarks>
        /// <returns></returns>
        private static string GetSubjectIdentifier()
        {
            var subjectIdentifier = "dictionary";
#if DEBUG
            subjectIdentifier = "Subject.RouteValues";
#endif
            return subjectIdentifier;
        }


    }
}
