using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.PasswordBoxSpecificaitons
{
	public class DefaultSpecification : VisibleComponentSpecification<PasswordBoxComponent<TestEntity>>
	{
		protected override void When()
		{
		}

		protected override string expectedRendering => "<input type=\"password\" />";
	}
}