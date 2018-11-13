using System;
using System.Linq.Expressions;

namespace MustardBlack.Html.Forms.Tests.ExpressionHelperSpecs.GetExpressionText
{
	public class IndexerNested : Specification
	{
		Expression<Func<TestClass, int>> property;
		string stringified;

		protected override void Given()
		{
			this.property = c => c.InnerList[5].Age;
		}

		protected override void When()
		{
			stringified = ExpressionHelper.GetExpressionText(property);
		}

		[Then]
		public void StringFromExpressionShouldBeCorrect()
		{
			this.stringified.ShouldEqual("InnerList[5].Age");
		}
	}
}