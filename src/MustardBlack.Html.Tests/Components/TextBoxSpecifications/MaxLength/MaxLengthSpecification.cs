using System;
using MustardBlack.Html.Components;
using MustardBlack.Html.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Tests.Components.TextBoxSpecifications.MaxLength
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