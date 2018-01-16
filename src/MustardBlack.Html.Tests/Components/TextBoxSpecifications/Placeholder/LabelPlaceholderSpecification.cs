using System;
using MustardBlack.Html.Components;
using MustardBlack.Html.Configuration;
using MustardBlack.Html.Tests.Components.ComponentSpecifications;
using NSubstitute;

namespace MustardBlack.Html.Tests.Components.TextBoxSpecifications.Placeholder
{
	public class LabelPlaceholderSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime?>>
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
			    .WithPlaceholder()
			    .WithLabel("label");
	    }

        protected override string expectedRendering => "<input type=\"text\" placeholder=\"resolved\" />";
    }
}