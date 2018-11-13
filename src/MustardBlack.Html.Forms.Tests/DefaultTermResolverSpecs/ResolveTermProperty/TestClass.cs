using System.Collections.Generic;

namespace MustardBlack.Html.Forms.Tests.DefaultTermResolverSpecs.ResolveTermProperty
{
	public class TestClass
	{
		public string AString { get; set; }
		public List<string> Strings { get; set; }
		public InnerTestClass InnerTestClass { get; set; }
		public List<InnerTestClass> InnerList { get; set; }
		public TestClass()
		{
			this.Strings = new List<string>(1);
			this.InnerTestClass = new InnerTestClass();
		}
	}
}