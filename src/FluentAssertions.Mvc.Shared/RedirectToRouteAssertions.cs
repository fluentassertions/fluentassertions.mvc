﻿using System;
using System.Collections.Generic;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System.Web.Mvc;

namespace FluentAssertions.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="RedirectToRouteResult"/> is in the expected state.
    /// </summary>
    public class RedirectToRouteAssertions : ReferenceTypeAssertions<RedirectToRouteResult, RedirectToRouteAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ContentResultAssertions" /> class.
        /// </summary>
        public RedirectToRouteAssertions(RedirectToRouteResult subject) : base(subject)
        {
        }

        /// <summary>
        /// Asserts that the redirect is permanent.
        /// </summary>
        /// <param name="expectedPermanent">Should the redirect be permanent.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public RedirectToRouteAssertions WithPermanent(bool expectedPermanent, string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion 
                .BecauseOf(reason, reasonArgs)
                .ForCondition(expectedPermanent == Subject.Permanent)
                .FailWith("Expected RedirectToRoute.Permanent to be {0}{reason}, but found {1}", expectedPermanent, Subject.Permanent);
            return this;
        }

        /// <summary>
        /// Asserts that the redirect has the expected route name.
        /// </summary>
        /// <param name="expectedRouteName">The expected route name.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public RedirectToRouteAssertions WithRouteName(string expectedRouteName, string reason = "", params object[] reasonArgs)
        {
            Execute.Assertion 
                .BecauseOf(reason, reasonArgs)
                .ForCondition(string.Equals(expectedRouteName, Subject.RouteName, StringComparison.InvariantCultureIgnoreCase))
                .FailWith("Expected RedirectToRoute.RouteName to be {0}{reason}, but found {1}", expectedRouteName, Subject.RouteName);

            return this;
        }

        /// <summary>
        /// Asserts that the redirect has the expected route value.
        /// </summary>
        /// <param name="key">The expected route value key.</param>
        /// <param name="expectedValue">The expected route value.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public RedirectToRouteAssertions WithRouteValue(string key, object expectedValue, string reason = "", params object[] reasonArgs)
        {
            var expected = new KeyValuePair<string, object>(key, expectedValue);

            ((IEnumerable<KeyValuePair<string, object>>)this.Subject.RouteValues).Should().Contain(expected, reason, reasonArgs);
            return this;
        }

        /// <summary>
        /// Asserts that the redirect has the expected controller name.
        /// </summary>
        /// <param name="expectedControllerName">The expected controller name.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public RedirectToRouteAssertions WithController(string expectedControllerName, string reason = "", params object[] reasonArgs)
        {
            WithRouteValue("Controller", expectedControllerName, reason, reasonArgs);
            return this;
        }

        /// <summary>
        /// Asserts that the redirect has the expected action.
        /// </summary>
        /// <param name="expectedAction">The expected action.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public RedirectToRouteAssertions WithAction(string expectedAction, string reason = "", params object[] reasonArgs)
        {
            WithRouteValue("Action", expectedAction, reason, reasonArgs);
            return this;
        }

        /// <summary>
        /// Asserts that the redirect has the expected area.
        /// </summary>
        /// <param name="expectedArea">The expected area.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        [CustomAssertion]
        public RedirectToRouteAssertions WithArea(string expectedArea, string reason = "", params object[] reasonArgs)
        {
            WithRouteValue("Area", expectedArea, reason, reasonArgs);
            return this;
        }

        /// <summary>
        /// Returns the type of the subject the assertion applies on.
        /// </summary>
        protected override string Identifier
        {
            get { return "RedirectToRouteResult"; }
        }
    }
}
