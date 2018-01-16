using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.HiddenFieldSpecifications
{
	public class WithValueSpecification : WithValueAttributeSpecification<HiddenFieldComponent<TestEntity, string>, string>
	{
		public override string expectedRendering => "<input type=\"hidden\" value=\"thevalue\" />";

		protected override string value => "thevalue";
	}
}