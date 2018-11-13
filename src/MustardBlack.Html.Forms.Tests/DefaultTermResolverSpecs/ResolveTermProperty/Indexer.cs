using System;
using System.Linq.Expressions;

namespace MustardBlack.Html.Forms.Tests.DefaultTermResolverSpecs.ResolveTermProperty
{
	public class Indexer : Specification
	{
		Expression<Func<TestClass, string>> property;
		string stringified;

		protected override void Given()
		{
			this.property = c => c.Strings[0];
		}

		protected override void When()
		{
			stringified = new DefaultTermResolver().ResolveTerm(this.property);
		}

		[Then]
		public void StringFromExpressionShouldBeCorrect()
		{
			this.stringified.ShouldEqual("Strings");
		}
	}
}