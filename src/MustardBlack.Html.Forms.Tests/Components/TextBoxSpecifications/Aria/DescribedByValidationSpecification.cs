using System;
using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.TextBoxSpecifications.Aria
{
	public class DescribedByValidationSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime?>>
    {
	    protected override void Given()
	    {
		    base.Given();

		    this.component.WithRenderingOrder(ComponentPart.ValidationMessage, ComponentPart.Component);
		}

	    protected override void When()
	    {
		    component
			    .WithAria()
			    .WithId("txtTest");
	    }

        protected override string expectedRendering => "<span id=\"txtTest_Validation\" class=\"field-validation-message\"></span><input type=\"text\" id=\"txtTest\" aria-describedby=\"txtTest_Validation\" />";
    }
}