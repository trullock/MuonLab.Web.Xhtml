using System;
using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Configuration;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;
using NSubstitute;

namespace MustardBlack.Html.Forms.Tests.Components.TextBoxSpecifications.Placeholder
{
	public class TermPlaceholderSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime?>>
    {
	    protected override void Given()
	    {
		    base.Given();

		    Dependency<ITermResolver>()
			    .ResolveTerm("term", this.culture)
			    .Returns("resolved");
	    }

	    protected override void When()
	    {
		    component
			    .WithPlaceholder("term")
			    .WithLabel("label");
	    }

        protected override string expectedRendering => "<input type=\"text\" placeholder=\"resolved\" />";
    }
}