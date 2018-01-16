using MustardBlack.Html.Components;
using MustardBlack.Html.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Tests.Components.HiddenFieldSpecifications
{
	public class WithValueSpecification : WithValueAttributeSpecification<HiddenFieldComponent<TestEntity, string>, string>
	{
		public override string expectedRendering => "<input type=\"hidden\" value=\"thevalue\" />";

		protected override string value => "thevalue";
	}
}