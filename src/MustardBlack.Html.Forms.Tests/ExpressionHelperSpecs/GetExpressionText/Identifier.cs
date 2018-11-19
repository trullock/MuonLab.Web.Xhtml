using System;
using System.Linq.Expressions;

namespace MustardBlack.Html.Forms.Tests.ExpressionHelperSpecs.GetExpressionText
{
    public class Identifier: Specification
    {
        Expression<Func<TestClass, string>> property;
        string stringified;

        protected override void Given()
        {
            this.property = c => c.Strings[0];
        }

        protected override void When()
        {
            stringified = new DefaultComponentIdResolver("prefix").ResolveId(property, "_hello_");
        }

        [Then]
        public void StringFromExpressionShouldBeCorrect()
        {
            this.stringified.ShouldEqual("prefix_hello_Strings[0]");
        }
    }
}