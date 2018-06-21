using System;
using System.Text;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
#if NETSTANDARD1_6
using Microsoft.AspNetCore.Mvc;
#else
using System.Web.Mvc;
#endif

namespace FluentAssertions.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="JsonResult"/> is in the expected state.
    /// </summary>
    public class JsonResultAssertions : ObjectAssertions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:JsonResultAssertions" /> class.
        /// </summary>
        public JsonResultAssertions(JsonResult subject) : base(subject)
        {
            
        }

        /// <summary>
        /// Asserts that the Data is exactly the same as the expected Data.
        /// This uses a standard object.Equals comparisson so the validity of this test will depend on the nature of the equality overrides (if any)
        /// </summary>
        /// <param name="expectedData">The expected content of the result.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public JsonResultAssertions WithData(object expectedData, string reason = "", params object[] reasonArgs)
        {
            var actual = (Subject as JsonResult).Data;

            Execute.Assertion
                .ForCondition(object.Equals(actual, expectedData))
                .BecauseOf(reason, reasonArgs)
                .FailWith(string.Format(FailureMessages.CommonFailMessage, "JsonResult.Data", expectedData, actual));

            return this;
        }

        /// <summary>
        /// Asserts that the Data is exactly the same as the expected Data.
        /// This uses a standard object.Equals comparisson so the validity of this test will depend on the nature of the equality overrides (if any)
        /// </summary>
        /// <param name="dataCondition">A predicate that validates the data.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public JsonResultAssertions WithData(Func<object, bool> dataCondition, string reason = "", params object[] reasonArgs)
        {
            var actual = (Subject as JsonResult).Data;

            Execute.Assertion
                .ForCondition(dataCondition(actual))
                .BecauseOf(reason, reasonArgs)
                .FailWith(string.Format(FailureMessages.JsonResult_WithDataPredicate, "JsonResult.Data", actual));

            return this;
        }

#if !NETSTANDARD1_6
        /// <summary>
        /// Asserts that the content encoding is the expected content encoding type.
        /// </summary>
        /// <param name="expectedEncoding">The expected content encoding type.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public JsonResultAssertions WithContentEncoding(Encoding expectedEncoding, string reason = "", params object[] reasonArgs)
        {
            Encoding actualContentEncoding = (Subject as JsonResult).ContentEncoding;

            Execute.Assertion
                .ForCondition(expectedEncoding == actualContentEncoding)
                .BecauseOf(reason, reasonArgs)
                .FailWith(string.Format(FailureMessages.CommonFailMessage, "JsonResult.ContentEncoding", expectedEncoding.ToString(), actualContentEncoding.ToString()));

            return this;
        }
#endif

    }
}