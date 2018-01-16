using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.HiddenFieldSpecifications
{
	public class WithIdSpecification : WithIdSpecification<HiddenFieldComponent<TestEntity, string>>
	{
        protected override string expectedRendering => "<input type=\"hidden\" id=\"theid\" />";
	}
}