using MustardBlack.Html.Components;
using MustardBlack.Html.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Tests.Components.HiddenFieldSpecifications
{
	public class WithAttrSpecification : WithAttrSpecification<HiddenFieldComponent<TestEntity, string>>
	{
        protected override string expectedRendering => "<input type=\"hidden\" misc=\"random\" />";
	}
}