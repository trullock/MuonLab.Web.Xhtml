using System;
using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Configuration;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;
using NSubstitute;

namespace MustardBlack.Html.Forms.Tests.Components.TextBoxSpecifications.Aria
{
	public class AriaLabelSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime?>>
    {
	    protected override void Given()
	    {
		    base.Given();

		    Dependency<ITermResolver>()
			    .ResolveTerm("label", this.culture)
			    .Returns("resolved");
	    }

	    protected override void When()
	    {
		    component
				.WithAria()
			    .WithLabel("label");
	    }

        protected override string expectedRendering => "<input type=\"text\" aria-label=\"resolved\" />";
    }
}