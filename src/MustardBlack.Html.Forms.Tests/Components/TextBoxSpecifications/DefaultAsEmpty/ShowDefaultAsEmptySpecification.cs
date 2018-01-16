using System;
using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.TextBoxSpecifications.DefaultAsEmpty
{
	public class ShowDefaultAsEmptySpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime>>
    {
        protected override void When()
        {
			component.ShowDefaultAsEmpty().WithValue(default(DateTime));
        }

        protected override string expectedRendering => "<input type=\"text\" />";
    }
}