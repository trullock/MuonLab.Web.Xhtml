using MustardBlack.Html.Components;
using MustardBlack.Html.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Tests.Components.HiddenFieldSpecifications
{
	public class WithIdSpecification : WithIdSpecification<HiddenFieldComponent<TestEntity, string>>
	{
        protected override string expectedRendering => "<input type=\"hidden\" id=\"theid\" />";
	}
}