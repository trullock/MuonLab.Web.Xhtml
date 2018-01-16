using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.HiddenFieldSpecifications
{
	public class WithAttrSpecification : WithAttrSpecification<HiddenFieldComponent<TestEntity, string>>
	{
        protected override string expectedRendering => "<input type=\"hidden\" misc=\"random\" />";
	}
}