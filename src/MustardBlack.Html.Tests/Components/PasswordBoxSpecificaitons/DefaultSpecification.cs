using MustardBlack.Html.Components;
using MustardBlack.Html.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Tests.Components.PasswordBoxSpecificaitons
{
	public class DefaultSpecification : VisibleComponentSpecification<PasswordBoxComponent<TestEntity>>
	{
		protected override void When()
		{
		}

		protected override string expectedRendering => "<input type=\"password\" />";
	}
}