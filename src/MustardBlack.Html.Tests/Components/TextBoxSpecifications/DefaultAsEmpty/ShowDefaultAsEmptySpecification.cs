using System;
using MustardBlack.Html.Components;
using MustardBlack.Html.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Tests.Components.TextBoxSpecifications.DefaultAsEmpty
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