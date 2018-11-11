using System;
using System.Linq.Expressions;

namespace MustardBlack.Html.Forms.Tests.ExpressionHelperSpecs.GetExpressionText
{
	public class Simple : Specification
	{
		Expression<Func<TestClass, string>> property;
		string stringified;

		protected override void Given()
		{
			this.property = c => c.AString;
		}

		protected override void When()
		{
			stringified = ExpressionHelper.GetExpressionText(property);
		}

		[Then]
		public void StringFromExpressionShouldBeCorrect()
		{
			this.stringified.ShouldEqual("AString");
		}
	}
}