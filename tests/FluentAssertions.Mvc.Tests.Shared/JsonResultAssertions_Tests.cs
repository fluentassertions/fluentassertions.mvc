using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
#if NETCOREAPP1_0
using Microsoft.AspNetCore.Mvc;
#else
using System.Web.Mvc;
#endif

namespace FluentAssertions.Mvc.Tests
{
    [TestFixture]
    public class JsonResultAssertions_Tests
    {
        [Test]
        public void WithJson_ShouldPass()
        {
            ActionResult result = new JsonResult { Data = new List<int>() };
            result.Should().BeJsonResult();
        }

        [Test]
        public void WithContentResult_ShouldFail()
        {
            ActionResult result = new ContentResult {Content = "{ \"name\" : \"WithJson_GivenExpected_ShouldPass\" }"};
            
            // this is a bit of a hack to build the expected message.  There must be a better way?
            var messageFormat = ActionResultAssertions.Constants.CommonFailMessage
                .Replace("{reason}","")
                .Replace("{", "\"{")
                .Replace("}", "}\"");
            var failureMessage = String.Format(messageFormat, typeof(JsonResult).Name, result.GetType().Name);
            
            System.Action act = () => result.Should().BeJsonResult();

            act.Should().Throw<System.Exception>().WithMessage(failureMessage);
        }

        #region WithData object
        [Test]
        public void WithData_DataIsSameObject()
        {
            var data = new int[] {10, 20, 30, 40};
            ActionResult result = new JsonResult { Data = data };
            
            result.Should().BeJsonResult().WithData(data);
        }

        [Test]
        public void WithData_DataIsDifferentObject()
        {
            var actualData = new int[] {10, 20, 30, 40};
            var differentData = new string[] {"10", "20", "30", "40"};
            ActionResult result = new JsonResult { Data = actualData };
            var expectedMessage = string.Format(FailureMessages.CommonFailMessage, "JsonResult.Data", differentData, actualData);

            System.Action act = () => result.Should().BeJsonResult().WithData(differentData);

            act.Should().Throw<Exception>().WithMessage(expectedMessage);
        }

        [Test]
        public void WithData_DataIsDifferentObjectOfSameValue()
        {
            var actualData = new ObjectWithEquality("hello world");
            var expectedData = new ObjectWithEquality("hello world");

            ActionResult result = new JsonResult { Data = actualData };
            
            result.Should().BeJsonResult().WithData(expectedData);
        }

        [Test]
        public void WithData_DataIsDifferentObjectOfDifferentValue()
        {
            var actualData = new ObjectWithEquality("hello world");
            var expectedData = new ObjectWithEquality("goodbye cruel world");
            var expectedMessage = string.Format(FailureMessages.CommonFailMessage, "JsonResult.Data", expectedData, actualData);

            ActionResult result = new JsonResult { Data = actualData };
            
            System.Action act = () => result.Should().BeJsonResult().WithData(expectedData);

            act.Should().Throw<Exception>().WithMessage(expectedMessage);
        }
        #endregion

        #region WithData predicate
        
        [Test]
        public void WithDataPredicate_ShouldPass()
        {
            var data = new int[] {10, 20, 30, 40};
            ActionResult result = new JsonResult { Data = data };
            
            result.Should().BeJsonResult().WithData(d =>
            {
                var isGood = false;

                if (d is IEnumerable<int> ids)
                {
                    isGood = ids.Contains(10) && ids.Contains(20);
                }
                return isGood;
            });
        }

        [Test]
        public void WithDataPredicate_ShouldFail()
        {
            var actualData = new int[] { 10, 20, 30, 40 };
            ActionResult result = new JsonResult { Data = actualData };
            var expectedMessage = string.Format(FailureMessages.JsonResult_WithDataPredicate, "JsonResult.Data", actualData);

            System.Action act = () => result.Should()
                .BeJsonResult()
                .WithData(d => false);

            act.Should().Throw<Exception>().WithMessage(expectedMessage);
        }

        //[Test]
        //public void WithData_DataIsDifferentObjectOfSameValue()
        //{
        //    var actualData = new ObjectWithEquality("hello world");
        //    var expectedData = new ObjectWithEquality("hello world");

        //    ActionResult result = new JsonResult { Data = actualData };

        //    result.Should().BeJsonResult().WithData(expectedData);
        //}

        //[Test]
        //public void WithData_DataIsDifferentObjectOfDifferentValue()
        //{
        //    var actualData = new ObjectWithEquality("hello world");
        //    var expectedData = new ObjectWithEquality("goodbye cruel world");
        //    var expectedMessage = string.Format(FailureMessages.CommonFailMessage, "JsonResult.Data", expectedData, actualData);

        //    ActionResult result = new JsonResult { Data = actualData };

        //    System.Action act = () => result.Should().BeJsonResult().WithData(expectedData);

        //    act.Should().Throw<Exception>().WithMessage(expectedMessage);
        //}

        #endregion

#if !NETCOREAPP1_0
        [Test]
        public void WithContentEncoding_GivenExpected_ShouldPass()
        {
            ActionResult result = new JsonResult { ContentEncoding = Encoding.ASCII };
            result.Should().BeJsonResult().WithContentEncoding(Encoding.ASCII);
        }

        [Test]
        public void WithContentEncoding_GivenUnexpected_ShouldFail()
        {
            var actualEncoding = Encoding.ASCII;
            var expectedEncoding = Encoding.Unicode;
            ActionResult result = new JsonResult { ContentEncoding = actualEncoding };
            var failureMessage = String.Format(FailureMessages.CommonFailMessage, "JsonResult.ContentEncoding", expectedEncoding, actualEncoding);

            Action a = () => result.Should().BeJsonResult().WithContentEncoding(expectedEncoding);
            
            a.Should().Throw<Exception>()
                .WithMessage(failureMessage);
        }
#endif

        private class ObjectWithEquality : IEquatable<ObjectWithEquality>
        {
            private readonly string _value;

            public ObjectWithEquality(string value)
            {
                _value = value;
            }

            public string Value => _value;

            #region Equality
            
            public bool Equals(ObjectWithEquality other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return string.Equals(Value, other.Value, StringComparison.CurrentCultureIgnoreCase);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((ObjectWithEquality) obj);
            }

            public override int GetHashCode()
            {
                return (Value != null ? StringComparer.CurrentCultureIgnoreCase.GetHashCode(Value) : 0);
            }

            public static bool operator ==(ObjectWithEquality left, ObjectWithEquality right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(ObjectWithEquality left, ObjectWithEquality right)
            {
                return !Equals(left, right);
            }
            
            #endregion

            public override string ToString()
            {
                return _value ?? "NULL";
            }
        }

    }
}