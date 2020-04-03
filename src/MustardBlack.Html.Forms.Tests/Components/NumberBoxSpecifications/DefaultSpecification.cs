using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.NumberBoxSpecifications
{
	public class DefaultSpecification : VisibleComponentSpecification<NumberBoxComponent<TestEntity, float>>
	{
		protected override void When()
		{
		}

		protected override string expectedRendering => "<input type=\"number\" value=\"0\" />";
	}
}