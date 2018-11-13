using System;
using System.Linq.Expressions;

namespace MustardBlack.Html.Forms.Tests.DefaultTermResolverSpecs.ResolveTermProperty
{
	public class IndexerNested : Specification
	{
		Expression<Func<TestClass, bool?>> property;
		string stringified;

		protected override void Given()
		{
			this.property = c => c.InnerList[0].Booly;
		}

		protected override void When()
		{
			stringified = new DefaultTermResolver().ResolveTerm(this.property);
		}

		[Then]
		public void StringFromExpressionShouldBeCorrect()
		{
			this.stringified.ShouldEqual("Booly");
		}
	}
}