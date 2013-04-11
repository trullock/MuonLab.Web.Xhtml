using MuonLab.Testing;

namespace MuonLab.Web.Xhtml.Tests.EnglishExtensionsSpecs.ToEnglish
{
	public sealed class EnumToEnglish : Specification
	{
		public enum TestEnum
		{
			Simple = 0,
			[DisplayName("Custom Name")]
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
			x.ToEnglish().ShouldEqual("Simple");
		}

		[Then]
		public void ShouldResolveComplicated()
		{
			var x = TestEnum.Complicated;
			x.ToEnglish().ShouldEqual("Custom Name");
		}

		[Then]
		public void ShouldResolveCaelCase()
		{
			var x = TestEnum.CamelCased;
			x.ToEnglish(LanguageMode.CamelCase).ShouldEqual("Camel Cased");
		}

		[Then]
		public void ShouldResolveUnderscores()
		{
			var x = TestEnum.CamelCased_WithFiller;
			x.ToEnglish(LanguageMode.CamelCase).ShouldEqual("Camel Cased - With Filler");
		}
	}
}