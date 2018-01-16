using MustardBlack.Html.Components;
using MustardBlack.Html.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Tests.Components.HiddenFieldSpecifications
{
	public class WithNameSpecification : WithNameSpecification<HiddenFieldComponent<TestEntity, string>>
	{
		protected override string expectedRendering => "<input type=\"hidden\" name=\"thename\" />";
	}
}