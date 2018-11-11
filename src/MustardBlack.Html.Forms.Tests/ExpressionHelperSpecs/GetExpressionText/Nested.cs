using System;
using System.Linq.Expressions;

namespace MustardBlack.Html.Forms.Tests.ExpressionHelperSpecs.GetExpressionText
{
	public class Nested : Specification
	{
		Expression<Func<TestClass, bool?>> property;
		string stringified;

		protected override void Given()
		{
			this.property = c => c.InnerTestClass.Booly;
		}

		protected override void When()
		{
			stringified = ExpressionHelper.GetExpressionText(property);
		}

		[Then]
		public void StringFromExpressionShouldBeCorrect()
		{
			this.stringified.ShouldEqual("InnerTestClass.Booly");
		}
	}
}