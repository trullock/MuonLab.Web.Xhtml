using System;
using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.TextBoxSpecifications.Aria
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