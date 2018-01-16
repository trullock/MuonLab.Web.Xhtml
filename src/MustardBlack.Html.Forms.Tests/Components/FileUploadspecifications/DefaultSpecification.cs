using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.FileUploadspecifications
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