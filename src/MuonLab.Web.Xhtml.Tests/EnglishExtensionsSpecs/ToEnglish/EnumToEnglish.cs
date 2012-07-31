using MuonLab.Testing;

namespace MuonLab.Web.Xhtml.Tests.EnglishExtensionsSpecs.ToEnglish
{
	public sealed class EnumToEnglish : Specification
	{
		public enum TestEnum
		{
			Simple = 0,
			[DisplayName("Custom Name")]
			Complicated = 1
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
	}
}