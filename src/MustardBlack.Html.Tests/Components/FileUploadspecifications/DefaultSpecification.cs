using MustardBlack.Html.Components;
using MustardBlack.Html.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Tests.Components.FileUploadspecifications
{
	public class DefaultSpecification : VisibleComponentSpecification<FileUploadComponent<TestEntity, string>>
	{
		protected override void When()
		{
			this.component.WithRenderingOrder(ComponentPart.Component);
		}

		protected override string expectedRendering => "<input type=\"file\" />";
	}
}