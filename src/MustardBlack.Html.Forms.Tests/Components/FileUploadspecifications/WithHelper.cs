using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.FileUploadspecifications
{
	public class WithHelper : VisibleComponentSpecification<FileUploadComponent<TestEntity, string>>
	{
		protected override void When()
		{
			this.component.WithRenderingOrder(ComponentPart.Component);
			this.component.WithHelperSpan();
		}

		protected override string expectedRendering => "<input type=\"file\" /><span class=\"field-helper\"></span>";
	}
}