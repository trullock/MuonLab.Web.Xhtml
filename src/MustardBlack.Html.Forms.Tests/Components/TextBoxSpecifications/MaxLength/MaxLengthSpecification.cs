using System;
using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.TextBoxSpecifications.MaxLength
{
	public class MaxLengthSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime?>>
    {
	    protected override void When()
	    {
		    component
			    .WithMaxLength(15);
	    }

        protected override string expectedRendering => "<input type=\"text\" maxlength=\"15\" />";
    }
}