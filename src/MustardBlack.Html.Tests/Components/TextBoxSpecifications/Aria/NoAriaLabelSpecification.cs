using System;
using MustardBlack.Html.Components;
using MustardBlack.Html.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Tests.Components.TextBoxSpecifications.Aria
{
	public class NoAriaLabelSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime?>>
    {
	    protected override void When()
	    {
		    component
				//.WithAria()
			    .WithLabel("label");
	    }

        protected override string expectedRendering => "<input type=\"text\" />";
    }
}