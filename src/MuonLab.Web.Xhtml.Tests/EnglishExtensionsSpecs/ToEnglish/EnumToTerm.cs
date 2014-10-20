using MuonLab.Testing;

namespace MuonLab.Web.Xhtml.Tests.EnglishExtensionsSpecs.ToEnglish
{
	public sealed class EnumToTerm : Specification
	{
		public enum TestEnum
		{
			Simple = 0,
			[Term("CustomKey")]
			Complicated = 1,
			CamelCased = 2,
			CamelCased_WithFiller = 3
		}

		protected override void When()
		{
			
		}

		[Then]
		public void ShouldResolveSimple()
		{
			var x = TestEnum.Simple;
			x.ToTerm().ShouldEqual("TestEnum_Simple");
		}

		[Then]
		public void ShouldResolveComplicated()
		{
			var x = TestEnum.Complicated;
			x.ToTerm().ShouldEqual("CustomKey");
		}

		[Then]
		public void ShouldResolveUnderscores()
		{
			var x = TestEnum.CamelCased_WithFiller;
			x.ToTerm().ShouldEqual("TestEnum_CamelCased_WithFiller");
		}
	}
}